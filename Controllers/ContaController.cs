using Microsoft.AspNetCore.Mvc;
using TransasoesBancarias.Models;

namespace TransasoesBancarias.Controllers
{
    public class ContaController : Controller
    {
        private Conta conta;
        private GerirContas gerirContas;
        public ContaController(Conta _conta, GerirContas vmc)
        {
            conta = _conta;
            gerirContas = vmc;
        }

        public IActionResult Index()
        {
            return View(conta);
        }
        public IActionResult NovaConta()
        {
            return View();
        }


        [HttpPost]
        public IActionResult NovaContaPOST(string nome, int numConta, int saldo)
        {
            if (gerirContas.Geranciador_Contas.Find(x => x.NumConta == numConta) is null)
            {
                Conta c = new Conta(gerirContas.Geranciador_Contas.Count + 1, numConta, nome, saldo);
                gerirContas.Geranciador_Contas.Add(c);
                return RedirectToAction("Index", conta);
            }
            return RedirectToAction("NovaConta");
        }
        [HttpPost]
        public IActionResult Transferir(double valor, int contaTo)
        {
            conta.Decrementa_Saldo(valor);
            gerirContas.Geranciador_Contas.Find(t => t.NumConta == contaTo).Incrementa_Saldo(valor);
            return RedirectToAction("Index", conta);
        }
        public IActionResult TransferirView()
        {
            return View(gerirContas);
        }

        public IActionResult DepositarView()
        {
            return View(conta);
        }
        public IActionResult ListarView()
        {
            return View(gerirContas);
        }
        [HttpPost]
        public IActionResult Depositar(double c)
        {
            conta.Incrementa_Saldo(c);
            return RedirectToAction("Index", conta);
        }

        public IActionResult SacarView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sacar(double c)
        {
            conta.Decrementa_Saldo(c);
            return RedirectToAction("Index", conta);
        }


    }
}
