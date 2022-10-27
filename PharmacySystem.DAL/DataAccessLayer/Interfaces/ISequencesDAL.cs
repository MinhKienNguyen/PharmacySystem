namespace PharmacySystem.DAL.DataAccessLayer.Interfaces
{
    public interface ISequencesDAL
    {
        string GetUnitSequenceId();
        string GetCustomerSequenceId();
        string GetInvoiceNoSequence();
        string GetProductSequence();
        string GetProductTypeSequence();
    }
}
