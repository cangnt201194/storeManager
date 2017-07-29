using AutoMapper;
using StoreManager.Model.Models;
using StoreManager.Service;
using StoreManager.Web.Infrastructure.Core;
using StoreManager.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StoreManager.Web.Infrastructure.Extensions;

namespace StoreManager.Web.API
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        /// <summary>
        /// loadAll
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _postCategoryService.GetAll();

                var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory);


                return response;
            });
        }
        /// <summary>
        /// create
        /// </summary>
        /// <param name="request"></param>
        /// <param name="postCategory"></param>
        /// <returns></returns>
        /// 
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.UpDatePostCategory(postCategoryVm);
                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, category);

                }
                return response;
            });
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="request"></param>
        /// <param name="postCategory"></param>
        /// <returns></returns>
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryDb = _postCategoryService.GetByID(postCategoryVm.ID);
                    postCategoryDb.UpDatePostCategory(postCategoryVm);
                    _postCategoryService.Update(postCategoryDb);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);

                }
                return response;
            });
        }

    }
}