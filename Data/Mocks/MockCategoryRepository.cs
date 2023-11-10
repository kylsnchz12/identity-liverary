namespace liveraryIdentity.Data.Mocks;
using liveraryIdentity.Data.Interfaces;
using liveraryIdentity.Models;
public class MockCategoryRepository:ICategoryRepository
{
    public IEnumerable<Category> Categories { 
        get 
        {
            return new List<Category>
            {
                new Category { CategoryName = "Amazon Web Services", CategoryDescription = "Desc nga long string ni", ImageUrl="/images/aws_bg.png"},
                new Category { CategoryName = "Python Programming", CategoryDescription = "Desc nga long string ni", ImageUrl="/images/python_bg.png"},
                new Category { CategoryName = "Javascript", CategoryDescription = "Desc nga long string ni", ImageUrl="/images/js_bg.png"},
                new Category { CategoryName = "Microsoft Azure", CategoryDescription = "Desc nga long string ni", ImageUrl="/images/ms_bg.png"},
            };
        }
    }
}