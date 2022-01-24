using AutoMapper;
using Business.Abstract;
using Business.Domain.Responses;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Enums;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ShipmentManager : IShipmentService
    {
        private readonly IShipmentDal _shipmentDal;
        private readonly ICategoryService _categoryService;
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IMapper _mapper;
        public ShipmentManager(IShipmentDal shipmentDal, ICategoryService categoryService, IMapper mapper,
            ICargoCompanyService cargoCompanyService)
        {
            _shipmentDal = shipmentDal;
            _categoryService = categoryService;
            _mapper = mapper;
            _cargoCompanyService = cargoCompanyService;
        }


        public IResult Add(int orderId)
        {
            var orderProducts = _categoryService.GetCategoryIdByOrderId(orderId).Data;
            foreach (var item in orderProducts)
            {
                var category = _categoryService.Get(item.CategoryId).Data;

                Shipment shipment = new Shipment();
                shipment.OrderId = item.OrderId;
                shipment.CargoCompanyId = category.CargoCompanyId;
                shipment.Status = ShipmentStatus.KargoHazirlaniyor;
                shipment.TrackingCode = Guid.NewGuid().ToString("N");
                _shipmentDal.Add(shipment);
            }
            return new SuccessResult();
        }

        public IDataResult<List<GetAllShipmentResponse>> GetShipmentByCargoCompany()
        {
            throw new NotImplementedException();
        }
    }
}
