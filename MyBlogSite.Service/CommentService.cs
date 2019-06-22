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
    public class CommentService : BaseService
    {
        //blog'a göre tüm yorumları getirme
        //blog id'si verilmektedir.
        public List<CommentDTO> GetComments(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var result = uow.Comments.Search(x => x.BlogId == id && x.IsConfirmed == false) .ToList();//tüm yorumları getirsin

                    List<CommentDTO> list = new List<CommentDTO>();

                    foreach (var item in result)
                    {
                        CommentDTO obj = new CommentDTO
                        {
                            CommentId = item.CommentId,
                            CommentContent = item.CommentContent,
                            BlogId = item.BlogId,
                            UserId = item.UserId,
                            IsConfirmed = item.IsConfirmed,
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




        //comment id si verilmektedir.
        public CommentDTO GetConfirmed(int id)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    //Search list dödüğünden hata vermektedir.
                    //Get fonk kullanırsak tek dğer döner ve hata kalkar.
                    var entity = uow.Comments.Get(x => x.CommentId == id);

                    var result= Mapper.Map<Comment, CommentDTO>(uow.Comments.Update(entity));
                    return result;
                    //   result.IsConfirmed = true;
                }
                catch (Exception ex)
                {
                    uow.RollBack();
                    return null;
                }

            }
        }
    }
}
