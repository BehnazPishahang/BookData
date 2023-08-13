using Application.Book;
using Application.UnitOfWork;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceModel;
using System.Linq;
using WebApi.Controllers.BaseController;

namespace BookData.Controllers.Book
{
    public class BookController : BaseController<BookDataRequest, BookDataResponse>
    {
        public IUnitOfWork _UnitOfWork { get; }

        public BookController(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("api/v1/[controller]/[action]")]
        public override async Task<BookDataResponse> GetAll()
        {
          
            var theBookList = await _UnitOfWork.Repositorey<IBookRepository>().GetAll();

            return new BookDataResponse()
            {
                theBookContractList = theBookList.Select(x => new ServiceModel.Book()
                {
                    Title = x.Title,

                    TheauthorList = x.TheAuthorList.Select(x => new author()
                    {
                        Name = x.Name

                    }).ToList()
                }).ToList()
            };
        }

        [HttpPost]
        [Route("api/v1/[controller]/[action]")]
        public async Task<ActionResult<BookDataResponse>> GetByTitle([FromBody] BookDataRequest request)
        {

          

            //todo
             var TheBook = await _UnitOfWork.Repositorey<IBookRepository>().GetByTitle(request.theBookDataContract.TheBookList.Select(x => x.Title));
           
            return new BookDataResponse()
            {
                theBookContractList = TheBook.Select(OneBook => new ServiceModel.Book()
                {
                    Title = OneBook.Title,
                  
                    TheauthorList = new List<ServiceModel.author>()
                    {
                      //todo
                    }
                }).ToList()
            };
           

        }

        [HttpPost]
        [Route("api/v1/[controller]/[action]")]
        public string AddBook([FromBody] BookDataRequest request)
        {

            Application.Domain.Book.Book OneBook = new()
            {

            };
            _UnitOfWork.Repositorey<IBookRepository>().Add(OneBook);
            _UnitOfWork.Commit();
            return "Succesful";

        }
    }
}
