namespace AutoCheck.ConsoleApp.Models

{
    public class ItemVistoria 
    {
        public string Nome { get; set; }
        public string Status { get; protected set; }

        public bool ValidarStatus(string Status)
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

        public void SetStatus(string status)
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