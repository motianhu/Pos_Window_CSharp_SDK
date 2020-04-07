using InvokeDll.http;
using InvokeDll.order.resp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace InvokeDll.order
{
    public class SaveOrder
    {
        public GoodsResponse requestOrder()
        {
            List<TicketDetailedOrderDto> dtos = new List<TicketDetailedOrderDto>();

            TicketDetailedOrderDto dto = new TicketDetailedOrderDto();
            dto.productCode = "00001734_00007342";
            dto.productId = "00007342";
            dto.productCount = 3;
            dto.productSdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dto.productType = "1";
            dtos.Add(dto);

            TicketOrderDto ticket = new TicketOrderDto();
            ticket.linkName = "jack";
            ticket.linkPhone = "13696969696";
            ticket.linkIcno = "458789878978997";
            ticket.scenicCode = "094529aa582c4b4e9c065943501a6ef3";
            ticket.scenicName = "W海花岛运营总公司";
            ticket.idenType = "1";
            ticket.userId = "5985";


            OrderDto orderDto = new OrderDto();
            orderDto.ticketDetailedOrderDtoList = dtos;
            orderDto.ticketOrderDto = ticket;

            String url = "http://61.141.236.3:2653/api/ticket/saveOrderTicketPOS";
            HttpClient httpClient = new HttpClient();
            GoodsResponse goods = httpClient.PostDataHttp<GoodsResponse>(url,null,null, JsonConvert.SerializeObject(orderDto));
            return goods;
        }
    }
}
