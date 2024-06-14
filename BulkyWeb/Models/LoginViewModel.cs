using System.ComponentModel.DataAnnotations;

namespace Bulky.Models;

public record LoginViewModel([Required]string Email,[Required]string Password);