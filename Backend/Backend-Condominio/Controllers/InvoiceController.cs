using AutoMapper;
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

        [HttpGet]
        public async Task<ActionResult<InvoiceDTO>> GetInvoices()
        {
            var invoice = await invoiceRepository.GetInvoices();
            return mapper.Map<InvoiceDTO>(invoice);
        }

        [HttpGet]
        public async Task<ActionResult<InvoiceDTO>> GetInvoicesPaginated([FromQuery] InvoiceFilter invoiceFilter)
        {
            var invoices = await invoiceRepository.GetInvoicesPaginated(invoiceFilter);
            if (invoices == null)
            {
                return NotFound();
            }

            return mapper.Map<InvoiceDTO>(invoices);

        }

        [HttpGet("{id}/{id}")]
        public async Task<ActionResult<InvoiceDTO>> GetInvoice([FromQuery] InvoiceFilter invoiceFilter)
        {
            var invoice = await invoiceRepository.GetInvoicesPaginated(invoiceFilter);
            if (invoice == null)
            {
                return NotFound();
            }

            return mapper.Map<InvoiceDTO>(invoice);

        }

        [HttpPost("{id}/user")]
        public async Task<ActionResult> PostUser(InvoiceCreationDTO invoiceCreationDTO)
        {
            var invoice = await invoiceRepository.CreateInvoiceForUser(invoiceCreationDTO);

            if (invoice == null)
            {
                return BadRequest();
            }

            var dto = mapper.Map<InvoiceDTO>(invoice);

            return new CreatedAtActionResult(nameof(GetInvoice), "Invoice", new { id = invoice.UserId, invoice.ActivityId }, dto);

        }

        [HttpPost]

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
