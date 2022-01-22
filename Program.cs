/*TASK ONE*/
void Task_One()
{
    float h, m;
    try
    {
        Console.WriteLine("Enter hours");
        h = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter minutes");
        m = int.Parse(Console.ReadLine());

        if (h > 11 || h < 0 || m > 59 || m < 0) throw new Exception("Number out of bounds");
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return;
    }
    int m_position = (int)(360 * (m / 60));
    int h_position = (int)(360 * (h / 12) + (m / 60) * 30);

    int result = (Math.Abs(m_position - h_position));

    if (result > 180) result = 360 - result;

    Console.WriteLine(result);
}
/*TASK TWO*/
int calc_depth(Branch branch)
{
    int max = int.MinValue;
    if (!branch.branches.Any()) return 1;
    foreach (Branch b in branch.branches)
    {
        int temp = calc_depth(b);
        if (temp > max) max = temp;
    }
    return max + 1;
}

// Branch original_structure = new Branch(); /*structure from the task pdf*/
// original_structure.branches.Add(new Branch());
// original_structure.branches[0].branches.Add(new Branch());
// original_structure.branches.Add(new Branch());
// original_structure.branches[1].branches.Add(new Branch());
// original_structure.branches[1].branches[0].branches.Add(new Branch());
// original_structure.branches[1].branches.Add(new Branch());
// original_structure.branches[1].branches[1].branches.Add(new Branch());
// original_structure.branches[1].branches[1].branches.Add(new Branch());
// original_structure.branches[1].branches[1].branches[0].branches.Add(new Branch());
// original_structure.branches[1].branches.Add(new Branch());
// Console.WriteLine(calc_depth(original_structure));

void menu()
{
    Branch root = new Branch();
    Branch selected_Branch = root;
    while (true)
    {
        Console.Write(@"
1. Add branch to current level.
2. Delve deeper into selected branch.
3. Go back to root branch.
4. Calculate depth from current level.
5. Display branches at this level.
6. Exit.
Choose your option:
");
        int choice = int.Parse(Console.ReadLine());
        Console.Write('\n');
        switch (choice)
        {
            case 1:
                selected_Branch.branches.Add(new Branch());
                Console.WriteLine("Added!");
                break;
            case 2:
                if (!selected_Branch.branches.Any())
                {
                    Console.WriteLine("Branch is empty");
                    continue;
                }
                Console.WriteLine("Choose branch to enter");
                for (int i = 0; i < selected_Branch.branches.Count(); i++)
                    Console.Write($"{i} ");
                Console.Write('\n');
                int choice_2 = int.Parse(Console.ReadLine());
                if (choice_2 > selected_Branch.branches.Count() - 1 || choice_2 < 0)
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }
                selected_Branch = selected_Branch.branches[choice_2];
                Console.WriteLine("Entered!");
                break;
            case 3:
                selected_Branch = root;
                Console.WriteLine("Went back to root!");
                break;
            case 4:
                Console.WriteLine(calc_depth(selected_Branch));
                break;
            case 5:
                if (!selected_Branch.branches.Any())
                {
                    Console.WriteLine("Branch is empty");
                    continue;
                }
                for (int i = 0; i < selected_Branch.branches.Count(); i++)
                    Console.Write($"{i} ");
                Console.Write('\n');
                break;
            case 6:
                return;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}

menu();

class Branch
{
    public List<Branch> branches;
    public Branch()
    {
        branches = new List<Branch>();
    }
}
