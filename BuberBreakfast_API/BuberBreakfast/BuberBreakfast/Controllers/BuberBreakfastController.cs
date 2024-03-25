using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using BuberBreakfast.Services.Breakfasts;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace BuberBreakfast.Controllers
{
        // hata kontrolünü problem içine aldık, artık basecontroller buradan depil api controllerdan gelecek,
    public class BuberBreakfastController : ApiController
    {

        
        private readonly IBreakfastService _breakfastService;

        public BuberBreakfastController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }

        [HttpPost]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            var breakfast = new Breakfast(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.StartDatetime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet
            );

            // serviste güncelleme yapmıştım burada da onları nesneye çektişm
            ErrorOr<Created> createBreakfastResult = _breakfastService.CreateBreakfast(breakfast);

            return createBreakfastResult.Match(
                created => CreatedAsGetBreakfast(breakfast),
                errors => Problem(errors)
            );
        }

      


        [HttpGet("{id:guid}")]
        public IActionResult GetBreakfast(Guid id)
        {

            ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);

            return getBreakfastResult.Match(
                breakfast => Ok(MapBreakfastResponse(breakfast)),
                errors => Problem(errors)
            );
        }

       

        [HttpPut("{id:guid}")]
        public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request){
            var breakfast = new Breakfast(
                id,
                request.Name,
                request.Description,
                request.StartDatetime,
                request.EndDateTime,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet
            );

            // yeni oluşturduğum UpsertedBreakfastdan aldım burayı 201 durumu için özel 
            ErrorOr<UpsertedBreakfast> upsertBreakfastResult =  _breakfastService.UpsertBreakfast(breakfast);

            return upsertBreakfastResult.Match(
                upserted => upserted.IsNewCreated ?  CreatedAsGetBreakfast(breakfast) : NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteBreakfast(Guid id){

            ErrorOr<Deleted> deletedBreakfastResult =  _breakfastService.DeleteBreakfast(id);

            // delete başarılı ise nocontent, error varsa apicontrollerdan problm fırlat
            return deletedBreakfastResult.Match(
                    deleted => NoContent(),
                    errors => Problem(errors)
            );
        }


         private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
        {
            return new BreakfastResponse(
                            breakfast.Id,
                            breakfast.Name,
                            breakfast.Description,
                            breakfast.StartDateTime,
                            breakfast.EndDateTime,
                            breakfast.LastModifiedDateTime,
                            breakfast.Savory,
                            breakfast.Sweet
                        );
        }


          private CreatedAtActionResult CreatedAsGetBreakfast(Breakfast breakfast)
        {
            return CreatedAtAction(
                actionName: nameof(GetBreakfast),
                routeValues: new { id = breakfast.Id },
                value: MapBreakfastResponse(breakfast));
        }

    }
}