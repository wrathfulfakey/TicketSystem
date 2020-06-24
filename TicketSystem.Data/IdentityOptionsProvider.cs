namespace TicketSystem.Data
{
    using Microsoft.AspNetCore.Identity;

    public static class IdentityOptionsProvider
    {
        public static void GetIdentityOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;

            // If user inputs 5 failed passwords in a row account with that email/username will be locked out for 5 minutes
            options.Lockout.MaxFailedAccessAttempts = 5;

            // User must have confirmed email otherwise he can't log in.
            options.SignIn.RequireConfirmedEmail = true;
        }
    }
}
