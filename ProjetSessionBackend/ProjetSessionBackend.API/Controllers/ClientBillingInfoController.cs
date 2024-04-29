using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs.ClientBillingInfo;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientBillingInfoController : BaseController
    {
        private readonly IClientBillingInfoRepository _clientBillingInfoRepository;
        
        public ClientBillingInfoController(
            IMapper mapper, 
            IClientBillingInfoRepository clientBillingInfoRepository) 
            : base(mapper)
        {
            _clientBillingInfoRepository = clientBillingInfoRepository;
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> GetAll()
        {
            var clientBillingInfos = await _clientBillingInfoRepository.GetAll();
            return Ok(Mapper.Map<IEnumerable<ClientBillingInfoResponse>>(clientBillingInfos));
        }
        
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Employee,Client")]
        public async Task<IActionResult> GetById(int id)
        {
            var clientBillingInfo = await _clientBillingInfoRepository.GetById(id);
            if (clientBillingInfo == null)
                return NotFound();
            
            return Ok(Mapper.Map<ClientBillingInfoResponse>(clientBillingInfo));
        }
        
        [HttpGet("user/{userId}")]
        [Authorize(Roles = "Admin,Employee,Client")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var clientBillingInfo = await _clientBillingInfoRepository.GetByUserId(userId);
            if (clientBillingInfo == null)
                return NotFound();
            
            return Ok(Mapper.Map<ClientBillingInfoResponse>(clientBillingInfo));
        }
        
        [HttpPost]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Create(CreateClientBillingInfoRequest request)
        {
            var clientBillingInfo = Mapper.Map<ClientBillingInfo>(request);
            var createdClientBillingInfo = await _clientBillingInfoRepository.Create(clientBillingInfo);
            
            var response = Mapper.Map<ClientBillingInfoResponse>(createdClientBillingInfo);
            return CreatedAtAction(nameof(GetById), new { id = response.ClientBillingInfoId }, response);
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedClientBillingInfo = await _clientBillingInfoRepository.Delete(id);
            if (deletedClientBillingInfo == null)
                return NotFound();
            
            return NoContent();
        }
    }
}
