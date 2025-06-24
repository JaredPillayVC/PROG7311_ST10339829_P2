namespace PROG7311_ST10339829_P2.Models
{
    /// <summary>
    /// ViewModel for representing error information.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Gets or sets the request ID associated with the error.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Indicates whether the RequestId should be shown.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}