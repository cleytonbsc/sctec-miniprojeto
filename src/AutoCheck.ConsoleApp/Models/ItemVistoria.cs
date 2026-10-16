namespace AutoCheck.ConsoleApp.Models

{
    public class ItemVistoria 
    {
        public String Nome { get; set; }
        public String Status { get; protected set; }

        public bool ValidarStatus(String Status)
        {
            if (Status != "Bom" && Status != "Regular" && Status != "Ruim")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SetStatus(String status)
        {
            while (!ValidarStatus(status))
            {
                Console.WriteLine("Status inválido. Digite novamente (Bom, Regular, Ruim):");
                status = Console.ReadLine();
            }
            this.Status = status;
        }   
    }
}