using HB.Application.DTOs;
using HB.Application.Features.Firms.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Hb.Api.Test
{
    public class FirmControllerTest : IClassFixture<HBApiFactory>
    {
        private readonly WebApplicationFactory<TestStartup> _factory;

        public FirmControllerTest(HBApiFactory factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task Post_Should_Fail_With_Error_Response_When_Firm_Name_Is_Empty()
        {
            //Arrange
            var firm = new CreateFirmCommand { Name = string.Empty,FirmType = 1 };
            var json = JsonSerializer.Serialize(firm);
            var client = _factory.CreateClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //Act
            var response = await client.PostAsync("/api/firms", content);
            var actualStatusCode = response.StatusCode;

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, actualStatusCode);
        }
    }
}
