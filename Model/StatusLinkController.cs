using devtask.Objects;
using devtask.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devtask.Model
{
    public class StatusLinkController
    {

        string initStatus = "init";
        List<Status> statuses;
        List<Transaction> transactions;

        public StatusLinkController()
        {
            statuses = new List<Status>();
            statuses.Add(new Status("init", true));
            statuses.Add(new Status("review", false));
            statuses.Add(new Status("consider", false));
            statuses.Add(new Status("reject", false));
            statuses.Add(new Status("accept", false));
            statuses.Add(new Status("have-lunch", false));
            statuses.Add(new Status("have-dinner", false));
            transactions = new List<Transaction>();
            transactions.Add(new Transaction(statuses.First(s => s.name == "init"), statuses.First(s => s.name == "review")));
            transactions.Add(new Transaction(statuses.First(s => s.name == "review"), statuses.First(s => s.name == "consider")));
            transactions.Add(new Transaction(statuses.First(s => s.name == "consider"), statuses.First(s => s.name == "accept")));
            transactions.Add(new Transaction(statuses.First(s => s.name == "consider"), statuses.First(s => s.name == "reject")));
            transactions.Add(new Transaction(statuses.First(s => s.name == "review"), statuses.First(s => s.name == "reject")));
            transactions.Add(new Transaction(statuses.First(s => s.name == "reject"), statuses.First(s => s.name == "review")));
            transactions.Add(new Transaction(statuses.First(s => s.name == "have-lunch"), statuses.First(s => s.name == "have-dinner")));
            getStatusLabels(initStatus, statuses, transactions);
        }



        List<StatusLink> statusLinksLst;
        private void getStatusLabels(string initStatus, List<Status> statuses, List<Transaction> transactions)
        {
            initStatusLinkLst(initStatus);
            convertListToLinkList(initStatus, statuses);
            linkStatusFromTransactions(initStatus, transactions);
            setStatusLabels(statuses);
            printResults(statuses);
        }

        private void initStatusLinkLst(string initStatus)
        {
            if (statusLinksLst == null)
            {
                statusLinksLst = new List<StatusLink>();
                statusLinksLst.Add(new StatusLink(initStatus, initStatus));
            }
        }

        //TODO : re-usable list , not to add already created list
        private void convertListToLinkList(string initStatus, List<Status> statuses)
        {
            foreach (Status status in statuses)
            {
                if (status.name == initStatus)
                    continue;
                statusLinksLst.Add(new StatusLink(status.name));
            }
        }

        private void linkStatusFromTransactions(string initStatus, List<Transaction> transactions)
        {
            StatusLink fromNode, toNode;
            foreach (Transaction tran in transactions)
            {
                fromNode = statusLinksLst.First(sLink => sLink.name == tran.from.name); // O(n)^2 !!
                toNode = statusLinksLst.First(sLink => sLink.name == tran.to.name); // O(n)^2 !!
                fromNode.name = tran.from.name;
                // if prev == next || put a loop | if it id so -1

                //   if (!toNode.prevLST.Contains(fromNode.name))
                fromNode.nextLST.Add(tran.to.name);
                //  else
                //      fromNode.nextLST.Add(PARAMS.LABEL_LOOP);
                //need to add root
                if (tran.from.name == initStatus)
                    fromNode.root = initStatus;
                toNode.prevLST.Add(tran.from.name);
                if (!String.IsNullOrEmpty(fromNode.root)) // not orphan
                    toNode.root = fromNode.root;
            }
        }

        //TODO : add to statuslist the status 
        private void setStatusLabels(List<Status> statuses)
        {
            Status status;
            foreach (StatusLink slink in statusLinksLst)
            {
                status = statuses.First(s => s.name == slink.name); // O(n)^2 !!
                if (status.labelsLst.Contains(PARAMS.LABEL_INIT))
                    continue;
                if (slink.nextLST.Count == 0)
                    status.labelsLst.Add(PARAMS.LABEL_FINAL);
                if (String.IsNullOrEmpty(slink.root))
                    status.labelsLst.Add(PARAMS.LABEL_ORPHAN);
            }
        }

        private void printResults(List<Status> statuses)
        {
            foreach (Status status in statuses)
            {
                Console.WriteLine(status.name + ":");
                foreach (string label in status.labelsLst)
                {
                    Console.WriteLine("* " + label);
                }
            }
        }

    }
}
