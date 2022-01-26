﻿using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Nsk.Web.Services.Data;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace Nsk.Web.Services.Controllers
{
    public class ImageController : Controller
    {
        public IDatabase Database { get; private set; }

        public ImageController(IDatabase database)
        {
            this.Database = database ?? throw new ArgumentNullException(nameof(database));
        }

        [HttpGet]
        public string Environment([FromServices] IWebHostEnvironment environment)
        {
            return environment.EnvironmentName;
        }

        [HttpGet]
        //[ResponseCache(Duration = 30)]
        public IActionResult Category(int id)
        {
            try
            {
                using var image = Database.GetCategoryThumbnail(id);
                var result = BuildHttpResponse(image);
                return File(result, "image/jpeg");
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        //[ResponseCache(Duration = 30)]
        public IActionResult Product(int id)
        {
            try
            {
                using var image = Database.GetProductThumbnail(id);
                var result = BuildHttpResponse(image);
                return File(result, "image/jpeg");
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        private static MemoryStream BuildHttpResponse(Image image)
        {
            var memoryStream = new MemoryStream();
            image.SaveAsJpeg(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }
    }
}
