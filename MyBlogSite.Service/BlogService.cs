using MyblogSite.Data;
using MyblogSite.Data.UnitOfWork;
using MyBlogSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Service
{
    public class BlogService:BaseService
    {
        public List<BlogDTO> GetBlogs()
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                try
                {
                    //sonuçları al
                    var result = uow.Blogs
                        .List()
                        .OrderByDescending(x => x.CreatedDate)
                        .ToList();

                    //sonuçları listeye atılacağı için liste oluştur..
                    List<BlogDTO> list = new List<BlogDTO>();

                    //sonuçların içinde 
                    foreach (var item in result)
                    {
                        BlogDTO obj=new BlogDTO
                        {

                            BlogId = item.BlogId,
                            Title = item.Title,
                            CategoryName = item.Category.CategoryName,
                            BlogContent = item.BlogContent.Length >= 250 ? item.BlogContent.Substring(0, 250) : item.BlogContent,
                            CreatedDate = item.CreatedDate,
                            RecordStatusName = item.RecordStatus.RecordStatusName
                        };
                        //her sonucu bir dto ya atadık
                        //ve bunu listeye ekleyelim..
                        list.Add(obj);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    
                    return null;
                }
            }
        }

        //id e göre veri getirme
        public BlogDTO Get(int id)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                //sorgu
                var result = uow.Blogs.Get(x=>x.BlogId==id);

                if (result==null)
                {
                    return null;
                }

                //entityi DTO çevirme Mapper
                //Mapper Classı oluşturmalıyız.
                //Map<Source,Target>
                BlogDTO blog = Mapper.Map<Blog, BlogDTO> (result);

                //bu değerler tabloda(entity de) yok
                //DTO da bulunuyor bunlara değerleri atanırken tablo bağlantısı yapılmalı
                blog.CategoryName = result.Category.CategoryName;
                blog.Author = result.User.FirstName + " " + result.User.LastName;
                blog.RecordStatusName = result.RecordStatus.RecordStatusName;

                return blog;

            }
            
            
        }


        public int Save(BlogDTO obj)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                try
                {
                    //kaydederken bazı değerlerin default gelmesini sağlayalım
                    obj.IsConfirmed = false;
                    obj.RecordStatusId = Convert.ToByte(Enums.RecordStatus.Aktif);
                    obj.CreatedDate = DateTime.Now;


                    var blogDTO = Mapper.Map<BlogDTO, Blog>(obj);

                    var entity = uow.Blogs.Save(blogDTO);

                    //Commmit işlemi yapmalıyız...
                    uow.Commit();

                    //kaydolan blogıd dönüyor
                    return entity.BlogId;

                }
                catch (Exception ex)
                {
                    //hata varsa değişikleri geri al
                    uow.RollBack();
                    return 0;
                }
            }
        }


        //onaylama
        public bool Confirm(int id)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                try
                {
                    //idye göre veri bulalım
                    var entity = uow.Blogs.Get(id);
                    //isconfirm(onay) değerini true yapalım
                    entity.IsConfirmed = true;
                    //entityi güncelleyelim
                    uow.Blogs.Update(entity);

                    return uow.Commit();

                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return false;
                }
            }

        }


        public bool Update(BlogDTO obj)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                try
                {
                    var entity = uow.Blogs.Update(Mapper.Map<BlogDTO,Blog>(obj));

                    return uow.Commit();
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return false;
                }
            }
        }

        //Kategoriye göre Blog yazılarını getirme
        public List<BlogDTO> GetBlogsByCategory(int id)
        {
            using (UnitOfWork uow=new UnitOfWork())
            {
                try
                {
                    //sorgu
                    var result = uow.Blogs
                        .Search(x => x.CategoryId == id)
                        .OrderByDescending(x => x.CreatedDate)
                        .ToList();
                    List<BlogDTO> list = new List<BlogDTO>();
                    foreach (var item in result)
                    {
                        BlogDTO obj = new BlogDTO
                        {
                            BlogId = item.BlogId,
                            Title = item.Title,
                            CategoryName = item.Category.CategoryName,
                            BlogContent = item.BlogContent.Substring(0, 250),
                            CreatedDate = item.CreatedDate
                        };
                        list.Add(obj);
                    }
                    return list;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
