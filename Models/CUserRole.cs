namespace vidly.Models
{
    public static class CUserRole
    {
        public static string MovieManager() => "CanManageMovies";
        public static string NormalizedMovieManager() => "CANMANAGEMOVIES";
        public static string CustomerManager() => "CanManageCustomer";
        public static string NormalizedCustomerManager() => "CANMANAGECUSTOMER";
    }
}