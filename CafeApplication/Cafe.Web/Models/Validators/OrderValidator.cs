using Cafe.Domain;
using FluentValidation;

namespace Cafe.Web.Models.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(order => order.IsCompleted).NotNull()
                                               .WithMessage("Is completed must be not null");
            RuleFor(order => order.CustomerName).NotEmpty()
                                                .NotNull()
                                                .WithMessage("Customer name must be not null");
            RuleFor(order => order.PaymentMethod).NotNull()
                                                 .WithMessage("Payment method must be not null");
            RuleFor(order => order.CustomerPhoneNumber).NotNull()
                                                       .Matches("^(\\+375|80)(29|25|44|33)(\\d{3})(\\d{2})(\\d{2})$")
                                                       .WithMessage("Phone number must be like this: +375(xx)xxxxxxx");
            RuleFor(order => order.OrderDate).NotEmpty()
                                             .NotNull()
                                             .WithMessage("Order date must be not null");
        }
    }
}
