﻿using AutoMapper;
using BrowserBlog.Browsers.Domain.Contracts.Repositories;
using BrowserBlog.Browsers.Domain.Contracts.Services;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using BrowserBlog.Browsers.Domain.Models.Entities;
using BrowserBlog.Browsers.Services.Services.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserBlog.Browsers.Services.Services
{
    public class BrowserService : BaseService<BrowserService>, IBrowserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowserService(IMapper mapper, ILogger<BrowserService> logger, IUnitOfWork unitOfWork) : base(mapper, logger)
        {
            _unitOfWork = unitOfWork;
        }

        public OperationResult<IEnumerable<BrowserDto>> GetBrowsersList()
        {
            try
            {
                var entities = _unitOfWork.GetRepository<Browser>().Get().ToList();
                return new OperationResult<IEnumerable<BrowserDto>>(Mapper.Map<IEnumerable<BrowserDto>>(entities));
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return new OperationResult<IEnumerable<BrowserDto>>("Internal server error");
            }
        }

        public async Task<OperationResult> AddBrowserAsync(BrowserDto browserDto)
        {
            try
            {
                var entity = Mapper.Map<Browser>(browserDto);
                await _unitOfWork.GetRepository<Browser>().AddAsync(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return new OperationResult("Internal server error");
            }

            return new OperationResult();
        }

        public async Task<OperationResult> UpdateBrowserDto(BrowserDto browserDto)
        {
            var entity = await _unitOfWork.GetRepository<Browser>().FindAsync(browserDto.Id);

            if (entity == null)
            {
                return new OperationResult($"Entity {browserDto.Id} not exists");
            }

            try
            {
                Mapper.Map(browserDto, entity);
                _unitOfWork.GetRepository<Browser>().Update(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return new OperationResult("Internal server error");
            }

            return new OperationResult();
        }

        public async Task<OperationResult> DeleteBrowser(Guid id)
        {
            var entity = await _unitOfWork.GetRepository<Browser>().FindAsync(id);

            if (entity == null)
            {
                return new OperationResult($"Entity {id} not exists");
            }

            try
            {
                _unitOfWork.GetRepository<Browser>().Delete(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return new OperationResult("Internal server error");
            }

            return new OperationResult();
        }
    }
}