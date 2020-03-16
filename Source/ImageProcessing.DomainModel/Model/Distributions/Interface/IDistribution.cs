namespace ImageProcessing.DomainModel.Model.Distributions.Interface
{
    /// <summary>
    /// Specifies a model
    /// of a continuous distribution.
    /// </summary>
    public interface IDistribution
    {
        /// <summary>
        /// The name of a distribution.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Specifies the first parameter of
        /// a distribution.
        /// </summary>
        decimal FirstParameter { get; }

        /// <summary>
        /// Specifies the second parameter of
        /// a distribution.
        /// </summary>
        decimal SecondParameter { get; }

        /// <summary>
        /// E[X] of a specified distribution.
        /// </summary>
        decimal GetMean();

        /// <summary>
        /// Var[X] of a specified distribution.
        /// </summary>
        decimal GetVariance();

        /// <summary>
        /// Q(p) of a specified distribution.
        /// </summary>
        bool Quantile(decimal p, out decimal quanile);

        /// <summary>
        ///Set parameters of a distribution.
        /// </summary>
        IDistribution SetParams((string First, string Second) parms);
    }
}