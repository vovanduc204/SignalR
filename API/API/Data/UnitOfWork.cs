﻿using API.Interfaces;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        IUserRepository IUnitOfWork.UserRepository => new UserRepository(_context, _mapper);

        IMessageRepository IUnitOfWork.MessageRepository => new MessageRepository(_context, _mapper);

        ILikesRepository IUnitOfWork.LikesRepository => new LikesRepository(_context);

        public IPhotoRepository PhotoRepository => new PhotoRepository(_context);

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
