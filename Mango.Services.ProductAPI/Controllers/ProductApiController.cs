﻿using AutoMapper;
using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/Product")]
    [ApiController]
    //[Authorize]
    public class ProductApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public ProductApiController (AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDto();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Product> objList = _db.Products.ToList();
                _response.Result = _mapper.Map<IEnumerable<ProductDto>>(objList);
               
            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
                
            }
            return _response;

        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Product obj = _db.Products.First(u => u.ProductId == id);
                _response.Result = _mapper.Map<ProductDto>(obj); 
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

       

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public ResponseDto Add([FromBody] ProductDto ProductDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(ProductDto);
                _db.Products.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }
        [HttpPut]
        //[Authorize(Roles = "ADMIN")]
        public ResponseDto Update([FromBody] ProductDto ProductDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(ProductDto);
                _db.Products.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<ProductDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }

        [HttpDelete]
        [Route("{id:int}")]
        //[Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Product obj = _db.Products.First(u => u.ProductId == id);
                _db.Products.Remove(obj);
                _db.SaveChanges();
               
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;

        }
    }
}
