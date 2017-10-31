using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xiaoshuai.Common;
using xiaoshuai.Repository.Entity;
using xiaoshuai.Repository.Repository;
using xiaoshuai.ViewModel;

namespace xiaoshuai.Services
{
    public class ManageService
    {
        private CategoryRepository categoryRepository = new CategoryRepository();

        public List<CategoryViewModel> GetCategory()
        {
            var result = categoryRepository.GetCategory();
            return AutoMapHelper.ToList<pub_CategoryEntity, CategoryViewModel>(result);
        }

        /// <summary>
        /// 后台航的数据源
        /// </summary>
        /// <returns></returns>
        public List<CategoryNavViewModel> GetCategoryNav()
        {
            var categorys = categoryRepository.GetCategory();
            var subCategorys = categoryRepository.GetSubCategoryWithArticleNum();
            var noSubCategorys = categoryRepository.GetCategoryWithArticleNum();
            List<CategoryNavViewModel> models = new List<CategoryNavViewModel>();

            foreach (var category in categorys)
            {
                CategoryNavViewModel model = new CategoryNavViewModel();
                model.categoryId = category.CategoryId;
                model.CategoryName = category.CategoryName;

                List<SubCategoryNavViewModel> SubCategory = new List<SubCategoryNavViewModel>();

                var thisSubs = subCategorys.Where(x => x.CategoryId == category.CategoryId);

                //未分类的数据
                var noSub = noSubCategorys.Where(x => x.CategoryId == category.CategoryId).First();
                SubCategoryNavViewModel sub = new SubCategoryNavViewModel();
                sub.SubCategoryId = noSub.SubCategoryId;
                sub.CategoryId = noSub.CategoryId;
                sub.SubCategoryName = noSub.SubCategoryName;
                sub.ArticleNum = noSub.ArticleNum;
                SubCategory.Add(sub);

                //有分类的数据
                foreach (var thissub in thisSubs)
                {
                    SubCategory.Add(new SubCategoryNavViewModel() { SubCategoryId = thissub.SubCategoryId, CategoryId = thissub.CategoryId, SubCategoryName = thissub.SubCategoryName, ArticleNum = thissub.ArticleNum });
                }
                model.SubCategory = SubCategory;
                models.Add(model);
            }
            return models;

        }

        /// <summary>
        /// 前台导航的数据源
        /// 没有文章不显示，没有子类显示为分类名称
        /// </summary>
        /// <returns></returns>
        public List<CategoryNavViewModel> GetMenu()
        {
            var categorys = categoryRepository.GetCategory();
            var subCategorys = categoryRepository.GetSubCategoryWithArticleNum();
            var noSubCategorys = categoryRepository.GetCategoryWithArticleNum();
            List<CategoryNavViewModel> models = new List<CategoryNavViewModel>();

            foreach (var category in categorys)
            {
                CategoryNavViewModel model = new CategoryNavViewModel();
                model.categoryId = category.CategoryId;
                model.CategoryName = category.CategoryName;
                List<SubCategoryNavViewModel> SubCategory = new List<SubCategoryNavViewModel>();
                if ("导航".Equals(category.CategoryName))
                {
                    SubCategory.Add(new SubCategoryNavViewModel() { SubCategoryId = "0", CategoryId = "0", SubCategoryName = "首页", ArticleNum = 1, Url = "/Home/Index" });
                }

                var thisSubs = subCategorys.Where(x => x.CategoryId == category.CategoryId);//子类
                var noSub = noSubCategorys.Where(x => x.CategoryId == category.CategoryId).First();
                if (thisSubs.Select(x => x.ArticleNum).Sum() != 0 || noSub.ArticleNum != 0)
                {
                    if (thisSubs.Count() == 0)
                    {
                        SubCategory.Add(new SubCategoryNavViewModel()
                        {
                            SubCategoryId = noSub.SubCategoryId,
                            CategoryId = noSub.CategoryId,
                            SubCategoryName = category.CategoryName,
                            ArticleNum = noSub.ArticleNum,
                            Url = string.Format("/Home/List/{0}/{1}.html", noSub.CategoryId, noSub.SubCategoryId)
                        });
                    }
                    //有分类的数据
                    foreach (var thissub in thisSubs)
                    {
                        if (thissub.ArticleNum > 1)
                        {
                            SubCategory.Add(new SubCategoryNavViewModel()
                            {
                                SubCategoryId = thissub.SubCategoryId,
                                CategoryId = thissub.CategoryId,
                                SubCategoryName = thissub.SubCategoryName,
                                ArticleNum = thissub.ArticleNum,
                                Url = string.Format("/Home/List/{0}/{1}.html", thissub.CategoryId, thissub.SubCategoryId)
                            });
                        }
                        else if (thissub.ArticleNum == 1)
                        {
                            SubCategory.Add(new SubCategoryNavViewModel()
                            {
                                SubCategoryId = thissub.SubCategoryId,
                                CategoryId = thissub.CategoryId,
                                SubCategoryName = thissub.SubCategoryName,
                                ArticleNum = thissub.ArticleNum,
                                Url = string.Format("/Home/Article/{0}", thissub.ArticleId)
                            });
                        }
                    }
                    model.SubCategory = SubCategory;
                    models.Add(model);
                }
            }
            return models;

        }

        public bool EditCategory(CategoryViewModel model)
        {
            pub_CategoryEntity entity = AutoMapHelper.ToEntity<CategoryViewModel, pub_CategoryEntity>(model);
            if (entity.Id == 0)
            {
                entity.CategoryId = IDHelper.Create("C");
                categoryRepository.InsertCategory(entity);
            }
            else
            {
                categoryRepository.UpdateCategory(entity);
            }
            return true;
        }

        public bool DeleteCategory(string categoryId)
        {
            categoryRepository.DeleteCategoryById(categoryId);
            return true;
        }

        public List<SubCategoryViewModel> GetSubCategoryByCategoryId(string categoryId)
        {
            var result = categoryRepository.GetSubCategoryByCategoryId(categoryId);
            return AutoMapHelper.ToList<pub_SubCategoryEntity, SubCategoryViewModel>(result);
        }

        public bool EditSubCategory(SubCategoryViewModel model)
        {
            pub_SubCategoryEntity entity = AutoMapHelper.ToEntity<SubCategoryViewModel, pub_SubCategoryEntity>(model);
            if (entity.Id == 0)
            {
                entity.SubCategoryId = IDHelper.Create("S");
                categoryRepository.InsertSubCategory(entity);
            }
            else
            {
                categoryRepository.UpdateSubCategory(entity);
            }
            return true;
        }

        public bool DeleteSubCategory(int id)
        {
            categoryRepository.DeleteSubCategoryById(id);
            return true;
        }

        public List<ComboxViewModel> GetCategoryComboxData(string id, string subId)
        {
            var categorys = GetCategory();
            List<ComboxViewModel> items = new List<ComboxViewModel>();

            bool hasSelected = false;//判断是否有满足，没有默认为第一条
            foreach (var category in categorys)
            {
                bool select = category.CategoryId == id;
                if (select) hasSelected = true;
                ComboxViewModel item = new ComboxViewModel();
                item.Category = "Category";
                item.IsSelect = select;
                item.Text = category.CategoryName;
                item.Value = category.CategoryId;
                item.Title = category.CategoryRemark;
                items.Add(item);
            }
            string categoryId = string.Empty;
            if (items.Count > 0)
            {
                var selectItem = items.Where(x => x.IsSelect).FirstOrDefault();
                if (selectItem != null)
                {
                    categoryId = selectItem.Value.ToString();
                }
                else
                {
                    categoryId = items.First().Value.ToString();
                }
            }

            var subCategorys = GetSubCategoryByCategoryId(categoryId);
            foreach (var subcategory in subCategorys)
            {
                ComboxViewModel item = new ComboxViewModel();
                item.Category = "SubCategory";
                item.IsSelect = subcategory.SubCategoryId == subId;
                item.Text = subcategory.SubCategoryName;
                item.Value = subcategory.SubCategoryId;
                item.Title = subcategory.SubCategoryRemark;
                items.Add(item);
            }
            return items;
        }

    }
}
