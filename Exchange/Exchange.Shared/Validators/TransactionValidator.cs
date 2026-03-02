using Exchange.Domain.Models;
using FluentValidation;

namespace Exchange.Shared.Validators;

public sealed class TransactionValidator : AbstractValidator<TransactionModel>
{
	public TransactionValidator()
	{
		RuleFor(x => x.Amount)
			.GreaterThan(0)
			.WithMessage("Amount must be greater than zero.");

		RuleFor(x => x.IdNumber)
			.NotEmpty()
			.WithMessage("ID number is required.");

		RuleFor(x => x.ExchangeRateId)
			.GreaterThan(0)
			.WithMessage("A valid exchange rate must be provided.");

		RuleFor(x => x.UserId)
			.NotEmpty()
			.WithMessage("A valid user must be provided.");

		RuleFor(x => x.FromCurrency)
			.NotEqual(x => x.ToCurrency)
			.WithMessage("From and To currencies must be different.");
	}
}
