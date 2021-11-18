using AutoMapper;
using BrowserBlog.Browsers.Domain.Contracts.Repositories;
using BrowserBlog.Browsers.Domain.Contracts.Services;
using BrowserBlog.Browsers.Domain.Models.Dtos;
using BrowserBlog.Browsers.Domain.Models.Entities;
using BrowserBlog.Browsers.Domain.Models.Errors;
using BrowserBlog.Browsers.Services.Services.Base;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserBlog.Browsers.Services.Services
{
    public class BrowserPageService : BaseService<BrowserPageService>, IBrowserPageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrowserPageService(IMapper mapper, ILogger<BrowserPageService> logger, IUnitOfWork unitOfWork) : base(mapper, logger)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> CreateBrowserPage(BrowserPageDto browserPageDto)
        {
            try
            {
                await _unitOfWork.GetRepository<BrowserPage>().AddAsync(Mapper.Map<BrowserPage>(browserPageDto));
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return new OperationResult(new InternalServerError());
            }
            
            return new OperationResult();
        }

        public async Task<OperationResult> DeleteBrowserPage(Guid id)
        {
            var entity = await _unitOfWork.GetRepository<BrowserPage>().FindAsync(id);

            if (entity == null)
            {
                Logger.LogError($"Entity {id} not found");
                return new OperationResult(new NotFoundError(id));
            }

            try
            {
                _unitOfWork.GetRepository<BrowserPage>().Delete(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return new OperationResult(new InternalServerError());
            }
            

            return new OperationResult();
        }

        public async Task<OperationResult> AddComment(Guid browserPageId, CommentDto commentDto)
        {
            var browserPageEntity = await _unitOfWork.GetRepository<BrowserPage>().FindAsync(browserPageId, false, browserPage => browserPage.Comments);

            if (browserPageEntity == null)
            {
                Logger.LogError($"Entity {browserPageId} not found");
                return new OperationResult(new NotFoundError(browserPageId));
            }

            try
            {
                var commentEntity = Mapper.Map<Comment>(commentDto);
                browserPageEntity.Comments.Add(commentEntity);
                _unitOfWork.GetRepository<BrowserPage>().Update(browserPageEntity);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return new OperationResult(new InternalServerError());
            }

            return new OperationResult();
        }

        public async Task<OperationResult<BrowserPageDto>> GetBrowserPage(Guid id)
        {
            var browserPageEntity = await _unitOfWork.GetRepository<BrowserPage>().FindAsync(id, true, browserPage => browserPage.Comments);

            if (browserPageEntity == null)
            {
                Logger.LogError($"Entity {id} not found");
                return new OperationResult<BrowserPageDto>(new NotFoundError(id));
            }

            return new OperationResult<BrowserPageDto>(Mapper.Map<BrowserPageDto>(browserPageEntity));
        }

        public OperationResult<ICollection<BrowserPageDto>> GetBrowsersTitlesList()
        {
            try
            {
                var entities = _unitOfWork.GetRepository<BrowserPage>().Get().ToList();
                return new OperationResult<ICollection<BrowserPageDto>>(Mapper.Map<ICollection<BrowserPageDto>>(entities));
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return new OperationResult<ICollection<BrowserPageDto>>(new InternalServerError());
            }
        }

        public async Task<OperationResult> UpdateBrowserPage(BrowserPageDto browserPageDto)
        {
            var entity = await _unitOfWork.GetRepository<BrowserPage>().FindAsync(browserPageDto.Id);

            if (entity == null)
            {
                Logger.LogError($"Entity {browserPageDto.Id} not found");
                return new OperationResult(new NotFoundError(browserPageDto.Id));
            }

            try
            {
                Mapper.Map(browserPageDto, entity);
                _unitOfWork.GetRepository<BrowserPage>().Update(entity);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, e.Message);
                return new OperationResult(new InternalServerError());
            }

            return new OperationResult();
        }
    }
}