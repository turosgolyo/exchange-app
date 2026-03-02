using Exchange.Domain.Models;
using FluentValidation;

namespace Exchange.Shared.Validators;

public sealed class ExchangeRateValidator : AbstractValidator<ExchangeRateModel>
{
	public ExchangeRateValidator()
	{
		RuleFor(x => x.ExchangeDate)
			.NotEmpty()
			.WithMessage("Exchange date is required.");

		RuleFor(x => x.UsdtoHUF)
			.GreaterThan(0)
			.WithMessage("USD to HUF rate must be greater than zero.");

		RuleFor(x => x.GbptoHUF)
			.GreaterThan(0)
			.WithMessage("GBP to HUF rate must be greater than zero.");

		RuleFor(x => x.ChftoHUF)
			.GreaterThan(0)
			.WithMessage("CHF to HUF rate must be greater than zero.");
	}
}
