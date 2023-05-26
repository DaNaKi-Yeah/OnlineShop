﻿using MediatR;

namespace OnlineShop.Application.CQRS.Properties.Commands.RemoveProperty
{
    public class RemoveByIdReviewCommand : IRequest
    {
        public int Id { get; set; }
    }
}
