using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Allers
{
    public class Context
    {
        public List<Item> listItems = new List<Item>();
        public List<Sale> listSales = new List<Sale>();
        public List<Client> listClients = new List<Client>();
        public List<List<Item>> listTransactions = new List<List<Item>>();

        public List<Item> getItems()
        {
            return listItems;
        }

        public List<Sale> getSales()
        {
            return listSales;
        }

        public List<Client> getClients()
        {
            return listClients;
        }

        public List<List<Item>> getTransactions()
        {
            return listTransactions;
        }

        public void setTransactions(List<List<Item>> newTransactions)
        {
            listTransactions = newTransactions;
        }

        public void loadData()
        {

            var dataClients = File.ReadLines("...\\...\\Clientes2.csv");
            var dataItems = File.ReadLines("...\\...\\Articulos2.csv");
            var dataSales = File.ReadLines("...\\...\\Ventas2.csv");

            foreach (var s in dataSales)
            {
                String[] data = s.Split(';');
                if (!s.Equals("") && data[4] != "NULL" && data[4] != "ItemCode")
                {

                    Sale newSale = new Sale();
                    newSale.cardCode = data[0];
                    newSale.docNum = (data[1]);
                    newSale.docDate = data[2];
                    newSale.docTotal = Convert.ToDouble(data[3]);
                    newSale.itemCode = data[4];
                    newSale.amount = Convert.ToInt32(data[5]);
                    newSale.price = Convert.ToDouble(data[6]);
                    newSale.totalLine = Convert.ToDouble(data[7]);
                    listSales.Add(newSale);
                    
                }
            }

            foreach (var s in dataItems)
            {
                String[] datos = s.Split(';');
                if (datos.Length > 1)
                {
                    if (datos[1] != "********" && datos[1] != "ItemName")
                    {

                        Item newItem = new Item();
                        newItem.itemCode = Convert.ToInt32(datos[0]);
                        newItem.itemName = datos[1];
                        listItems.Add(newItem);

                    }
                }
                else
                {
                    break;
                }

            }

            foreach (var s in dataClients)
            {
                String[] datos = s.Split(';');
                if (s.Equals(""))
                {
                    break;
                }
                if (!s.Equals("") && datos[2] != "NULL" && datos[3] != "NULL" && datos[1] != "GroupName")
                {
                    Client newClient = new Client();
                    newClient.CardCode = datos[0].Trim();
                    newClient.GroupName = datos[1].Trim();
                    newClient.City = datos[2].Trim();
                    newClient.Dpto = datos[3].Trim();
                    newClient.PymntGruoup = datos[4].Trim();
                    newClient.items = new double[listItems.Count()];
                    listClients.Add(newClient);
                }
            }
            loadTransactions();
            calculatePursaches();
            //Console.WriteLine(articulos.Count());
            //Console.WriteLine(ventas.Count());
            for (int i = 0; i < listItems.Count(); i++)
            {
                foreach (Sale sale in listSales)
                {
                    if (sale.itemCode.Equals(listItems[i].itemCode + ""))
                    {
                        try
                        {
                            listClients.First(k => k.CardCode.Equals(sale.cardCode)).items[i] += 1;
                            Console.WriteLine("holi");
                        }
                        catch { }
                    }
                }
            }
            int h = 0;
        }

        public void loadTransactions()
        {
            List<List<Item>> trans = new List<List<Item>>();
            var cons = listSales.GroupBy(x => x.docNum);
            foreach (var s in cons)
            {
                List<Item> temp = new List<Item>();
                foreach (var r in s)
                {
                    try
                    {
                        temp.Add(listItems.First(x => x.itemCode.Equals(Convert.ToInt32(r.itemCode))));
                    }
                    catch (Exception e)
                    {

                    }

                }
                trans.Add(temp);
            }
            listTransactions = trans;
        }

        public void calculatePursaches()
        {
            foreach (Client actual in listClients)
            {
                double pursaches = 0;
                var sales = listSales.Where(i => i.cardCode.Equals(actual.CardCode));
                foreach (Sale venta in sales)
                {
                    pursaches += venta.totalLine;
                }
                actual.Purchases = pursaches;
            }
        }

    }
}
