using DataAccess.Models;


namespace DataAccess
{
    public class DemoRepository
    {
        SignalRdemoContext _context;
        public DemoRepository(SignalRdemoContext context)
        {
            this._context = context;
        }

        public async Task<Demo> GetMessageById(int id)
        {
            Demo demo;
            Demo demoFail = new Demo();
            try
            {
                demo = await _context.Demos.FindAsync(id);
                if (demo != null)
                {
                    return demo;
                } 
                else 
                {
                    demoFail.Id = -1;
                    demoFail.Message = "No se encontro Demo";
                    demoFail.Number = -1;
                    return demoFail;
                }
            }
            catch (Exception)
            {
                demoFail.Id = -99;
                demoFail.Message = "Excepcion encontrada";
                demoFail.Number = -99;
                return demoFail;
            }   
        }

    }
}