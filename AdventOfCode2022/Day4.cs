﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal class Day4 : Day
    {
        public override void Run()
        {
            string[] lines = input.Split("\r\n");
            int numPairs = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                // left, right
                string[] sides = line.Split(",");
                // start, end
                string[] left = sides[0].Split("-");
                string[] right = sides[1].Split("-");
                // no real reason to do this except it makes the part below prettier :D
                (int, int, int, int) vals = (
                    Convert.ToInt32(left[0]),
                    Convert.ToInt32(left[1]),
                    Convert.ToInt32(right[0]),
                    Convert.ToInt32(right[1]));

                //Console.WriteLine(vals.ToString());

                // Part 1
                // left contains right
                /*
                if (vals.Item1 <= vals.Item3 && vals.Item2 >= vals.Item4)
                {
                    numPairs++;
                    continue;
                }
                // right contains left
                if (vals.Item3 <= vals.Item1 && vals.Item4 >= vals.Item2)
                {
                    numPairs++;
                    continue;
                }
                */
                // If left ends after right starts AND right ends after left starts 
                if (vals.Item2 >= vals.Item3 && vals.Item4 >= vals.Item1)
                {
                    numPairs++;
                }
            }

            Console.WriteLine("There are {0} containing pairs.", numPairs);
        }

        string input = "31-31,32-40\r\n26-92,13-91\r\n9-90,29-91\r\n72-72,25-73\r\n28-79,79-79\r\n52-77,53-53\r\n17-54,17-54\r\n11-47,4-10\r\n1-96,1-97\r\n38-99,39-63\r\n19-54,18-53\r\n1-73,1-73\r\n17-34,18-34\r\n93-93,25-94\r\n96-98,7-95\r\n58-97,73-98\r\n7-64,8-64\r\n87-91,67-90\r\n42-78,77-85\r\n24-96,24-97\r\n71-78,72-97\r\n5-28,27-29\r\n19-86,86-90\r\n19-85,20-20\r\n64-65,1-64\r\n28-78,27-81\r\n79-91,80-95\r\n32-89,32-82\r\n3-96,2-4\r\n70-83,15-70\r\n5-90,8-91\r\n16-60,16-61\r\n38-97,39-90\r\n25-56,6-55\r\n12-14,13-13\r\n11-95,11-96\r\n13-16,12-22\r\n15-29,14-72\r\n68-88,67-69\r\n23-95,94-97\r\n63-77,62-64\r\n19-69,20-85\r\n23-63,61-62\r\n7-47,6-47\r\n39-86,39-86\r\n98-99,4-98\r\n4-6,5-88\r\n41-89,88-89\r\n14-95,96-98\r\n6-62,3-62\r\n1-68,6-68\r\n25-90,40-90\r\n11-81,10-12\r\n2-91,1-91\r\n35-62,27-61\r\n14-28,14-28\r\n13-78,14-79\r\n51-52,46-52\r\n6-77,77-78\r\n98-99,50-98\r\n7-23,24-85\r\n38-56,38-62\r\n96-99,1-97\r\n32-32,31-31\r\n5-89,4-6\r\n22-84,21-85\r\n14-40,39-89\r\n40-91,40-91\r\n3-6,4-60\r\n48-59,60-60\r\n2-92,2-92\r\n34-35,7-34\r\n32-64,33-64\r\n36-56,36-55\r\n95-96,44-96\r\n91-99,37-92\r\n10-98,11-96\r\n24-68,69-94\r\n98-99,37-98\r\n99-99,6-87\r\n11-90,11-12\r\n76-87,36-77\r\n19-97,10-99\r\n47-77,78-93\r\n96-96,21-96\r\n50-97,99-99\r\n3-50,2-81\r\n18-69,19-69\r\n17-92,16-16\r\n18-72,19-72\r\n1-76,5-77\r\n14-97,98-99\r\n28-90,19-89\r\n19-47,47-48\r\n10-97,9-97\r\n11-96,11-85\r\n20-22,20-97\r\n1-94,1-95\r\n49-52,48-53\r\n3-3,3-34\r\n12-97,85-96\r\n49-84,48-84\r\n3-89,89-90\r\n68-96,41-96\r\n69-80,2-65\r\n16-81,16-81\r\n1-96,95-99\r\n49-99,49-94\r\n28-92,91-95\r\n2-95,1-99\r\n12-30,8-31\r\n21-68,26-69\r\n6-31,2-31\r\n49-66,49-65\r\n55-67,55-68\r\n21-50,20-44\r\n14-42,15-43\r\n70-89,70-89\r\n3-99,1-3\r\n7-86,6-37\r\n58-71,68-71\r\n55-83,55-82\r\n61-99,11-99\r\n83-83,3-84\r\n25-82,25-81\r\n14-48,15-54\r\n97-98,13-96\r\n25-63,63-63\r\n4-81,37-82\r\n12-98,98-98\r\n31-34,33-56\r\n3-83,1-82\r\n33-99,99-99\r\n96-99,39-97\r\n82-84,43-77\r\n95-99,1-96\r\n83-84,6-83\r\n58-60,58-58\r\n51-92,92-93\r\n93-93,33-93\r\n1-93,92-97\r\n16-16,16-31\r\n10-55,54-55\r\n56-64,63-70\r\n18-88,10-19\r\n55-95,5-95\r\n62-77,48-61\r\n3-65,56-65\r\n54-55,55-56\r\n22-70,23-70\r\n18-91,18-18\r\n91-98,2-99\r\n9-56,8-56\r\n84-92,17-83\r\n98-98,25-99\r\n22-63,66-84\r\n4-50,2-5\r\n12-13,12-49\r\n30-85,31-79\r\n57-83,57-87\r\n13-79,13-79\r\n30-38,17-87\r\n64-65,5-64\r\n99-99,29-99\r\n28-75,7-27\r\n3-79,3-67\r\n10-90,24-89\r\n10-53,83-91\r\n39-74,35-39\r\n52-78,53-78\r\n2-87,3-95\r\n58-68,57-68\r\n6-32,31-51\r\n18-36,18-35\r\n3-99,3-99\r\n8-81,7-80\r\n50-53,51-52\r\n91-92,84-92\r\n19-91,5-18\r\n40-68,68-69\r\n30-90,52-91\r\n20-27,19-26\r\n98-99,99-99\r\n27-58,28-58\r\n61-61,45-62\r\n67-75,60-77\r\n69-70,68-72\r\n1-96,4-93\r\n2-95,38-96\r\n56-57,11-56\r\n54-84,6-53\r\n65-85,5-66\r\n22-84,21-84\r\n50-64,51-53\r\n7-75,74-81\r\n34-69,34-70\r\n35-35,6-35\r\n8-96,69-96\r\n13-98,13-97\r\n80-80,55-81\r\n16-62,6-98\r\n2-87,63-87\r\n84-91,7-92\r\n3-3,4-98\r\n3-80,52-80\r\n80-94,11-79\r\n2-95,1-71\r\n31-96,95-95\r\n9-65,64-65\r\n61-69,60-97\r\n2-99,2-98\r\n18-73,19-21\r\n80-80,80-82\r\n47-70,47-71\r\n13-30,23-30\r\n16-41,17-41\r\n3-13,12-79\r\n72-75,73-87\r\n13-13,13-81\r\n29-74,30-73\r\n24-43,7-42\r\n1-93,92-93\r\n4-47,4-93\r\n8-10,9-96\r\n2-87,5-88\r\n51-61,50-64\r\n60-64,60-63\r\n26-66,27-73\r\n13-85,14-86\r\n42-43,42-92\r\n45-72,44-44\r\n83-83,84-99\r\n3-5,6-97\r\n10-92,10-10\r\n43-69,44-69\r\n49-50,15-50\r\n4-91,4-91\r\n51-52,20-51\r\n7-84,1-96\r\n6-76,5-76\r\n15-19,14-14\r\n57-68,46-69\r\n80-80,3-81\r\n4-93,7-92\r\n37-40,38-41\r\n8-49,16-49\r\n6-86,86-87\r\n71-85,71-85\r\n35-68,69-96\r\n57-96,2-56\r\n13-33,5-32\r\n14-97,14-97\r\n83-98,60-99\r\n4-24,10-25\r\n1-84,2-84\r\n75-86,70-74\r\n22-79,1-78\r\n94-94,10-93\r\n6-70,7-70\r\n25-56,16-20\r\n2-87,1-88\r\n50-52,51-92\r\n2-68,3-42\r\n3-93,92-92\r\n8-97,96-96\r\n90-93,77-94\r\n61-98,6-99\r\n30-47,16-47\r\n27-92,26-26\r\n18-32,19-32\r\n23-76,19-21\r\n8-43,23-44\r\n9-93,10-93\r\n64-85,84-86\r\n2-88,88-89\r\n51-77,32-78\r\n53-83,25-52\r\n74-97,74-99\r\n99-99,7-98\r\n3-96,3-96\r\n67-67,68-69\r\n3-96,2-99\r\n18-95,17-19\r\n41-43,42-59\r\n3-5,5-5\r\n4-98,3-98\r\n41-69,70-88\r\n21-90,20-89\r\n76-78,77-81\r\n12-47,46-46\r\n33-85,34-84\r\n12-14,13-91\r\n46-59,45-59\r\n73-79,72-94\r\n7-18,6-8\r\n35-94,94-95\r\n15-18,15-18\r\n22-94,23-68\r\n15-16,15-81\r\n71-71,39-72\r\n61-61,11-62\r\n38-69,84-98\r\n76-80,76-79\r\n8-71,71-72\r\n27-94,28-71\r\n5-34,5-69\r\n48-62,35-61\r\n30-30,31-95\r\n45-96,95-99\r\n27-86,28-87\r\n72-72,44-72\r\n3-90,2-96\r\n31-98,30-71\r\n77-77,8-78\r\n19-99,18-20\r\n96-96,88-97\r\n10-30,7-8\r\n46-94,46-94\r\n9-34,33-96\r\n34-79,7-78\r\n31-77,32-76\r\n25-50,26-49\r\n37-70,36-38\r\n31-58,32-58\r\n12-97,12-98\r\n85-91,7-86\r\n57-77,4-78\r\n18-64,64-64\r\n73-74,72-74\r\n1-42,1-2\r\n30-99,37-98\r\n35-97,31-97\r\n17-57,57-58\r\n65-86,19-85\r\n27-95,50-97\r\n16-75,3-74\r\n44-87,86-94\r\n4-52,3-8\r\n31-96,95-95\r\n13-39,1-40\r\n29-95,71-95\r\n8-93,6-6\r\n1-97,2-98\r\n2-9,10-90\r\n22-24,19-23\r\n12-95,31-87\r\n1-77,7-78\r\n10-83,3-9\r\n60-88,60-87\r\n46-76,41-75\r\n21-57,20-57\r\n70-86,70-99\r\n46-56,55-72\r\n4-80,14-20\r\n14-55,13-71\r\n4-21,3-22\r\n2-91,2-92\r\n10-54,9-55\r\n1-3,2-98\r\n2-94,1-97\r\n3-89,3-4\r\n3-91,10-90\r\n11-13,10-68\r\n70-79,69-71\r\n42-77,42-77\r\n16-97,1-97\r\n18-82,82-86\r\n8-51,8-60\r\n21-70,20-70\r\n4-93,5-92\r\n46-46,6-45\r\n9-88,8-88\r\n26-92,15-91\r\n16-17,16-66\r\n58-65,7-65\r\n19-21,20-54\r\n48-93,48-93\r\n42-86,43-85\r\n28-44,28-44\r\n13-13,14-97\r\n10-72,73-73\r\n94-94,15-95\r\n44-67,26-66\r\n16-97,15-94\r\n74-74,9-75\r\n8-43,1-51\r\n33-58,34-57\r\n25-29,54-79\r\n21-77,29-76\r\n30-31,30-93\r\n88-96,42-87\r\n11-92,10-93\r\n25-72,2-73\r\n1-99,4-99\r\n33-56,33-80\r\n16-93,15-94\r\n36-39,34-38\r\n31-68,31-31\r\n20-89,88-90\r\n87-87,43-87\r\n12-14,11-14\r\n5-27,5-28\r\n28-70,71-71\r\n16-98,25-97\r\n13-89,12-12\r\n27-33,10-34\r\n97-99,54-95\r\n12-84,85-89\r\n39-58,40-57\r\n43-44,43-54\r\n92-94,93-95\r\n47-48,47-87\r\n10-31,9-30\r\n5-96,4-97\r\n67-70,67-71\r\n20-52,53-72\r\n44-65,38-66\r\n34-55,34-94\r\n1-98,6-89\r\n4-83,57-82\r\n94-95,4-93\r\n57-58,17-58\r\n8-38,5-9\r\n5-88,87-87\r\n17-76,75-77\r\n5-9,5-10\r\n31-36,28-31\r\n50-50,44-51\r\n19-89,19-89\r\n34-54,35-96\r\n54-60,32-64\r\n56-78,56-77\r\n39-39,39-39\r\n21-22,20-21\r\n52-76,51-53\r\n62-89,63-71\r\n40-85,40-70\r\n5-15,16-90\r\n42-83,41-46\r\n40-98,4-98\r\n29-94,28-54\r\n62-92,91-98\r\n8-94,9-93\r\n83-88,51-88\r\n4-60,7-60\r\n41-72,41-49\r\n31-57,51-56\r\n49-99,49-94\r\n79-79,10-80\r\n21-86,57-87\r\n42-44,23-43\r\n7-94,8-94\r\n24-32,24-33\r\n32-51,39-52\r\n12-28,27-82\r\n50-63,50-97\r\n58-64,64-64\r\n72-72,73-77\r\n51-65,51-51\r\n41-98,42-98\r\n97-98,1-97\r\n5-76,5-75\r\n83-93,42-92\r\n87-87,2-88\r\n26-41,26-27\r\n68-71,67-70\r\n61-62,36-62\r\n6-66,1-31\r\n57-73,15-72\r\n11-97,96-97\r\n4-99,4-98\r\n22-54,22-54\r\n18-43,43-43\r\n2-39,3-7\r\n24-91,99-99\r\n98-98,48-97\r\n3-70,3-71\r\n71-85,81-84\r\n93-98,2-92\r\n79-86,9-80\r\n30-61,60-83\r\n31-37,23-36\r\n25-95,26-95\r\n43-56,42-69\r\n18-28,5-27\r\n11-87,12-86\r\n58-99,59-97\r\n3-3,3-70\r\n31-41,17-30\r\n14-27,14-15\r\n2-70,3-94\r\n2-93,1-93\r\n38-90,39-79\r\n57-99,1-79\r\n70-95,70-78\r\n24-89,23-88\r\n4-84,19-83\r\n46-70,5-47\r\n10-70,71-73\r\n13-95,14-95\r\n48-52,49-52\r\n20-22,21-21\r\n88-88,1-88\r\n39-84,45-83\r\n28-75,28-75\r\n17-17,17-95\r\n3-98,97-97\r\n9-21,9-97\r\n28-37,27-34\r\n32-47,32-46\r\n13-28,27-72\r\n43-65,5-43\r\n22-48,47-48\r\n8-90,91-95\r\n51-53,10-52\r\n34-65,30-65\r\n1-98,1-2\r\n65-79,13-79\r\n74-74,13-75\r\n31-33,32-99\r\n4-95,38-94\r\n10-90,90-91\r\n62-62,4-61\r\n14-24,24-46\r\n4-85,10-84\r\n15-83,14-83\r\n1-85,3-86\r\n12-12,13-13\r\n15-89,14-90\r\n72-94,23-73\r\n11-69,8-68\r\n20-90,16-17\r\n5-95,32-96\r\n49-71,49-91\r\n22-89,22-89\r\n4-43,5-5\r\n51-98,15-97\r\n85-85,28-85\r\n18-61,18-81\r\n88-89,56-88\r\n71-79,72-79\r\n3-84,19-85\r\n18-18,19-85\r\n15-15,4-15\r\n46-71,44-71\r\n56-88,7-89\r\n37-50,36-51\r\n84-84,55-83\r\n14-27,15-26\r\n74-76,22-75\r\n77-99,77-95\r\n13-44,20-45\r\n6-95,12-96\r\n11-41,10-12\r\n10-76,17-77\r\n8-84,9-85\r\n14-64,13-15\r\n5-82,3-3\r\n43-53,42-44\r\n14-74,2-75\r\n12-97,12-98\r\n59-93,93-94\r\n17-81,15-82\r\n87-91,24-92\r\n8-84,9-84\r\n20-94,93-99\r\n46-97,97-98\r\n87-97,52-97\r\n2-90,3-91\r\n36-74,38-73\r\n55-59,55-55\r\n49-69,48-59\r\n54-62,54-96\r\n49-74,10-48\r\n27-78,26-26\r\n31-31,29-30\r\n2-76,1-90\r\n10-98,7-97\r\n14-15,14-93\r\n24-95,95-98\r\n13-23,22-23\r\n6-66,5-5\r\n85-86,66-86\r\n3-97,96-99\r\n1-93,1-90\r\n27-77,27-28\r\n51-64,51-51\r\n13-83,6-83\r\n40-54,53-54\r\n3-94,1-4\r\n15-29,15-28\r\n6-83,84-95\r\n62-62,8-63\r\n12-76,13-76\r\n3-7,5-7\r\n10-93,11-98\r\n28-28,28-63\r\n11-34,10-98\r\n6-8,7-49\r\n8-22,6-34\r\n29-47,29-49\r\n97-97,53-80\r\n20-99,21-75\r\n3-56,7-57\r\n43-63,43-64\r\n3-99,2-99\r\n24-99,24-25\r\n40-41,40-59\r\n60-63,60-60\r\n13-87,3-14\r\n70-88,25-88\r\n39-96,96-97\r\n11-53,12-52\r\n35-48,48-49\r\n11-53,9-25\r\n65-75,74-91\r\n74-80,80-80\r\n10-12,12-13\r\n46-73,74-84\r\n4-80,81-99\r\n4-84,83-91\r\n6-86,40-79\r\n46-82,22-81\r\n15-40,16-39\r\n5-86,45-93\r\n4-31,3-5\r\n40-84,31-83\r\n6-88,5-88\r\n8-79,12-80\r\n10-94,9-95\r\n81-81,23-81\r\n9-28,1-9\r\n47-99,46-83\r\n24-41,24-85\r\n10-67,9-35\r\n28-61,16-61\r\n6-6,7-71\r\n42-87,10-99\r\n97-97,2-97\r\n38-43,37-44\r\n15-86,15-87\r\n3-93,3-4\r\n85-86,84-87\r\n3-94,1-3\r\n32-47,47-47\r\n47-47,28-48\r\n4-97,4-98\r\n11-18,37-61\r\n31-38,30-38\r\n1-37,3-37\r\n23-60,61-99\r\n93-98,37-94\r\n8-97,9-97\r\n59-95,59-59\r\n81-87,13-80\r\n6-97,4-16\r\n15-27,27-73\r\n12-95,4-96\r\n54-96,22-55\r\n72-76,71-81\r\n5-94,6-92\r\n24-78,25-78\r\n55-64,52-63\r\n51-65,59-64\r\n32-87,32-58\r\n7-58,34-58\r\n29-83,29-82\r\n3-94,3-95\r\n84-84,71-85\r\n4-98,3-5\r\n17-36,18-37\r\n38-49,37-50\r\n14-61,94-99\r\n61-82,96-96\r\n25-98,98-99\r\n63-78,64-64\r\n43-49,42-50\r\n43-47,43-47\r\n14-62,23-63\r\n7-97,9-64\r\n49-82,49-90\r\n2-59,2-60\r\n53-85,53-86\r\n1-99,56-99\r\n26-92,26-60\r\n70-83,2-52\r\n54-55,54-85\r\n37-71,70-77\r\n87-91,15-92\r\n11-61,12-61\r\n9-9,7-10\r\n22-53,20-54\r\n88-89,1-88\r\n9-80,79-91\r\n43-85,43-59\r\n34-88,35-87\r\n9-98,24-97\r\n80-85,7-79\r\n9-38,38-39\r\n56-56,56-67\r\n79-90,79-89\r\n29-61,60-61\r\n1-95,1-96\r\n60-66,60-66\r\n41-75,74-74\r\n18-55,54-77\r\n4-98,3-97\r\n5-14,2-13\r\n9-51,9-55\r\n26-62,35-63\r\n85-97,84-96\r\n2-99,98-98\r\n67-94,67-94\r\n10-18,17-96\r\n12-99,13-13\r\n8-99,10-99\r\n20-28,21-27\r\n77-87,58-78\r\n38-51,38-59\r\n19-90,19-59\r\n24-98,37-74\r\n49-88,28-89\r\n18-85,84-85\r\n36-48,37-48\r\n70-92,91-93\r\n45-50,45-91\r\n82-93,44-50\r\n1-97,97-99\r\n45-58,44-59\r\n4-21,20-78\r\n56-83,57-57\r\n92-92,25-92\r\n33-36,35-35\r\n17-86,22-74\r\n12-86,86-87\r\n36-41,2-40\r\n34-34,35-35\r\n12-95,94-98\r\n88-89,32-99\r\n13-90,12-31\r\n3-90,1-1\r\n9-96,9-99\r\n8-60,13-61\r\n91-96,97-97\r\n19-58,18-20\r\n4-4,4-76\r\n2-57,2-75\r\n97-99,18-93\r\n15-37,38-86\r\n55-94,54-87\r\n15-35,16-94\r\n15-57,59-97\r\n14-90,14-91\r\n25-53,54-54\r\n87-97,86-97\r\n8-13,48-75\r\n5-80,3-3\r\n65-79,65-78\r\n1-73,72-73\r\n67-69,46-67\r\n50-67,49-67\r\n23-59,22-59\r\n2-27,1-96\r\n14-33,1-32\r\n30-82,16-30\r\n8-18,14-19\r\n30-30,27-30\r\n99-99,11-56\r\n25-26,25-38\r\n61-66,65-65\r\n44-77,93-97\r\n36-36,37-93\r\n11-45,10-10\r\n32-57,31-56\r\n98-99,41-96\r\n98-99,11-99\r\n6-8,7-79\r\n18-87,45-87\r\n22-84,22-92\r\n3-91,9-81\r\n5-78,6-78\r\n1-83,82-95\r\n54-61,54-61\r\n67-86,66-94\r\n17-85,17-86\r\n41-41,41-66\r\n57-68,14-67\r\n6-7,7-96\r\n10-96,72-98\r\n21-73,20-74\r\n35-98,9-97\r\n98-98,12-99\r\n6-48,5-96\r\n18-96,97-98\r\n19-21,20-52\r\n10-71,1-72\r\n2-35,2-2\r\n13-85,85-86\r\n29-81,81-82\r\n5-77,78-96\r\n40-41,28-41\r\n2-92,1-91\r\n7-81,28-82\r\n38-72,37-39\r\n58-85,25-85\r\n3-43,2-4\r\n30-58,31-79\r\n73-76,22-74\r\n43-73,44-74\r\n47-83,46-82\r\n64-92,63-69\r\n49-90,90-90\r\n11-98,11-97\r\n45-83,44-64\r\n18-65,38-65\r\n7-97,6-98\r\n9-67,11-77\r\n10-99,9-98\r\n11-41,10-58\r\n91-91,20-44\r\n2-99,2-98\r\n69-77,70-81\r\n45-73,46-55\r\n16-17,16-17\r\n13-76,75-81\r\n9-38,9-18\r\n42-64,3-41\r\n2-8,7-54\r\n53-58,28-59\r\n86-87,2-86\r\n93-93,13-94\r\n99-99,17-98\r\n55-63,60-60\r\n9-54,8-54\r\n89-95,94-95\r\n30-87,86-86\r\n14-16,15-96\r\n9-90,8-8\r\n41-95,40-94\r\n75-91,88-91\r\n9-13,8-10\r\n5-93,93-93\r\n19-41,19-41\r\n58-65,57-59\r\n56-99,55-70\r\n76-76,3-68\r\n98-98,46-92\r\n73-89,74-76\r\n78-93,26-78\r\n26-26,27-77\r\n57-76,75-75\r\n64-82,64-98\r\n64-91,21-80\r\n30-65,64-64\r\n43-43,43-87\r\n29-93,28-92\r\n94-95,13-95\r\n23-95,22-86\r\n18-85,84-84\r\n23-34,22-99\r\n82-84,77-84\r\n11-30,11-31\r\n6-34,33-34\r\n19-59,19-60\r\n4-66,65-72\r\n57-75,24-58\r\n26-55,34-54\r\n23-62,17-61\r\n1-89,3-92\r\n20-38,20-37\r\n10-98,10-11\r\n5-93,58-87\r\n89-90,62-90\r\n69-70,38-69\r\n36-63,62-63\r\n38-49,39-92\r\n86-87,22-87\r\n99-99,52-78\r\n16-99,16-92\r\n62-64,63-64\r\n87-88,69-87\r\n55-78,69-78\r\n5-15,15-72\r\n52-60,16-61\r\n4-97,1-96\r\n2-85,19-85\r\n5-10,1-22\r\n37-81,31-82\r\n21-91,12-90\r\n70-71,37-70\r\n64-64,65-92\r\n40-93,94-98\r\n38-84,83-85\r\n44-97,44-98\r\n31-31,10-31\r\n28-96,27-27\r\n32-79,35-78\r\n72-93,8-88\r\n7-77,7-58\r\n8-93,2-8\r\n5-91,28-90\r\n2-96,1-96\r\n52-56,51-54\r\n8-85,6-85\r\n4-84,6-49\r\n9-98,2-8\r\n61-97,46-60\r\n95-96,66-94\r\n98-98,86-99\r\n27-28,27-97\r\n54-85,55-86\r\n91-91,35-90\r\n4-89,10-88\r\n6-97,5-80\r\n34-57,35-37\r\n6-98,6-98\r\n12-67,31-68\r\n35-93,34-36\r\n11-60,39-61\r\n66-81,40-96\r\n57-57,8-56\r\n15-79,10-80\r\n78-79,27-79\r\n45-62,46-63\r\n14-35,35-71\r\n12-49,11-13\r\n51-67,67-67\r\n67-68,54-68\r\n55-93,13-41\r\n22-91,21-23\r\n92-95,88-96\r\n82-94,82-94\r\n99-99,2-97\r\n6-46,6-46\r\n39-75,1-40\r\n8-54,54-55\r\n78-93,77-93\r\n67-95,95-95\r\n2-4,3-98\r\n17-95,94-94\r\n36-51,42-50\r\n1-95,1-94\r\n67-96,67-95\r\n7-78,3-77\r\n18-48,17-47\r\n76-96,5-95\r\n45-45,21-46\r\n48-76,47-76\r\n36-38,33-38\r\n17-33,13-70\r\n78-93,78-78\r\n3-50,2-50\r\n8-8,8-84\r\n33-97,33-96\r\n51-53,52-87\r\n21-42,22-42\r\n98-99,2-98\r\n8-99,8-97\r\n41-51,41-51\r\n20-75,68-74\r\n2-98,98-99\r\n46-95,68-88\r\n16-69,68-97\r\n41-96,95-97\r\n1-98,1-98\r\n35-93,35-97\r\n54-66,1-97\r\n29-98,29-97\r\n44-44,44-67\r\n7-69,69-69\r\n3-74,73-73\r\n8-78,9-75\r\n43-51,51-52\r\n13-49,48-48\r\n42-76,3-76\r\n16-50,9-55\r\n62-71,62-71\r\n79-98,7-66\r\n43-58,58-58\r\n25-30,25-54\r\n2-17,16-27\r\n88-99,15-87\r\n33-94,94-94\r\n9-11,10-43\r\n38-97,39-95\r\n17-58,18-57\r\n25-97,17-62\r\n9-19,10-26\r\n87-88,86-87\r\n23-58,22-59\r\n49-96,49-49\r\n64-81,31-70\r\n3-85,2-86\r\n10-10,9-28\r\n9-51,5-9\r\n49-57,48-57\r\n1-65,3-66\r\n54-70,70-71\r\n2-61,1-60\r\n90-98,57-91\r\n";
    }
}