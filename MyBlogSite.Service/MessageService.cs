﻿using MyblogSite.Data;
using MyblogSite.Data.UnitOfWork;
using MyBlogSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.Service
{
    public class MessageService : BaseService
    {
        public bool SendMessage(MessageDTO obj)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                obj.CreatedDate = DateTime.Now;
                var entity = uow.Messages.Save(Mapper.Map<MessageDTO, Message>(obj));

                return uow.Commit();
            }
        }

        public List<MessageDTO> List()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var result = uow.Messages
                    .List()
                    .OrderByDescending(x => x.CreatedDate)
                    .ToList();

                if (result.Count == 0)
                {
                    return null;
                }

                List<MessageDTO> list = new List<MessageDTO>();

                foreach (var item in result)
                {
                    MessageDTO obj = Mapper.Map<Message, MessageDTO>(item);

                    list.Add(obj);
                }

                return list;

            }
        }
    }
}
