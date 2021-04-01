using AutoMapper;

using Backend_Condominio.DTOs.Filters;
using Backend_Condominio.DTOs.Invoice;
using Backend_Condominio.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Controllers
{
    [ApiController]
    [Route("api/invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceRepository invoiceRepository;
        private readonly IMapper mapper;

        public InvoiceController(InvoiceRepository invoiceRepository,
            IMapper mapper)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
        }

        [HttpGet("paginate")]
        public async Task<ActionResult<List<InvoiceDTO>>> GetInvoicesPaginated([FromQuery] InvoiceFilter invoiceFilter)
        {
            var invoices = await invoiceRepository.GetInvoicesPaginated(invoiceFilter,IncludeAll);
            if (invoices == null)
            {
                return NotFound();
            }

            return mapper.Map<List<InvoiceDTO>>(invoices);

        }

        private InvoiceIncludeFilters IncludeAll => new ()
        {
            IncludeActivity =true,
            IncludeTypePayments =true,
            IncludePayments =true,
            IncludeUser =true
        };

        [HttpGet("{activityId}/{userId}")]
        public async Task<ActionResult<InvoiceDTO>> GetInvoice(int activityId , string userId)
        {
            var invoice = await invoiceRepository.GetInvoice(userId, activityId, IncludeAll);
            if (invoice == null)
            {
                return NotFound();
            }

            return mapper.Map<InvoiceDTO>(invoice);

        }

        [HttpPost]
        public async Task<ActionResult> PostUser( InvoiceCreationDTO invoiceCreationDTO)
        {
            var invoice = await invoiceRepository.CreateInvoiceForUser(invoiceCreationDTO);

            if (invoice == null)
            {
                return BadRequest();
            }

            var dto = mapper.Map<InvoiceDTO>(invoice);

            return new CreatedAtActionResult(nameof(GetInvoice), "Invoice", new { id = invoice.UserId, invoice.ActivityId }, dto);

        }

        [HttpDelete]

        public async Task<ActionResult> DeleteInvoice(
            InvoiceFilter invoiceFilter)
        {
            var invoice = await invoiceRepository.DeleteInvoice(invoiceFilter);
            if (!invoice)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
