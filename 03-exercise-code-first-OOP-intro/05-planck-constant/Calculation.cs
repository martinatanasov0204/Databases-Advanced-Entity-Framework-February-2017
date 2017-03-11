namespace _05_planck_constant
{
    public class Calculation
    {
        public const double PlanckConstant = 6.62606896e-34;
        public const double Pi = 3.14159;

        public static double reducedPlanck()
        {
            return PlanckConstant / (2 * Pi);
        }
    }
}
