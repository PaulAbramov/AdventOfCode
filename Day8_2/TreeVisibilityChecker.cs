namespace Day8_2;

public static class TreeVisibilityChecker
{
    /// <summary>
    /// Row and Column have the same sizes(?)
    /// Check which quadrant the number is in, so possibly shorten the time of checks
    /// </summary>
    /// <param name="xPosition"></param>
    /// <param name="yPosition"></param>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static bool IsVisibleFromOutside(int xPosition, int yPosition, int[,] grid)
    {
        List<Func<bool>> functions = new List<Func<bool>>();

        var rowLength = (int)Math.Sqrt(grid.Length);

        if (xPosition == 0
            || yPosition == 0
            || yPosition == rowLength - 1
            || xPosition == rowLength - 1)
        {
            return true;
        }

        int treeHeightToCompare = grid[xPosition, yPosition];

        // Calculate in which quadrant we are
        int quadrant = (xPosition / (rowLength / 2)) * 2 + (yPosition / (rowLength / 2));
        switch (quadrant)
        {
            // top left quadrant
            case 0:
                functions.Add(bool() => VisibleCheckFromLeft(xPosition, yPosition, grid, treeHeightToCompare));
                functions.Add(bool() => VisibleCheckFromTop(xPosition, yPosition, grid, treeHeightToCompare));
                functions.Add(bool() => VisibleCheckFromRight(xPosition, yPosition, grid, rowLength, treeHeightToCompare));
                functions.Add(bool() => VisibleCheckFromDown(xPosition, yPosition, grid, rowLength, treeHeightToCompare));
                break;
            // top right quadrant
            case 1:
                functions.Add(bool() => VisibleCheckFromRight(xPosition, yPosition, grid, rowLength, treeHeightToCompare));
                functions.Add(bool() => VisibleCheckFromTop(xPosition, yPosition, grid, treeHeightToCompare));
                functions.Add(bool() => VisibleCheckFromLeft(xPosition, yPosition, grid, treeHeightToCompare));
                functions.Add(bool() => VisibleCheckFromDown(xPosition, yPosition, grid, rowLength, treeHeightToCompare));
                break;
            // bottom left quadrant
            case 2:
                functions.Add(bool() => VisibleCheckFromLeft(xPosition, yPosition, grid, treeHeightToCompare));
                functions.Add(bool() => VisibleCheckFromDown(xPosition, yPosition, grid, rowLength, treeHeightToCompare));
                functions.Add(bool() => VisibleCheckFromRight(xPosition, yPosition, grid, rowLength, treeHeightToCompare));
                functions.Add(bool() => VisibleCheckFromTop(xPosition, yPosition, grid, treeHeightToCompare));
                break;
            // bottom right quadrant
            case 3:
                functions.Add(bool() => VisibleCheckFromRight(xPosition, yPosition, grid, rowLength, treeHeightToCompare));
                functions.Add(bool() => VisibleCheckFromDown(xPosition, yPosition, grid, rowLength, treeHeightToCompare));
                functions.Add(bool() => VisibleCheckFromLeft(xPosition, yPosition, grid, treeHeightToCompare));
                functions.Add(bool() => VisibleCheckFromTop(xPosition, yPosition, grid, treeHeightToCompare));
                break;
        }

        // Execute all checks in the order
        return functions.Any(function => function());
    }

    private static bool VisibleCheckFromLeft(int xPosition, int yPosition, int[,] grid, int valueToCompare)
    {
        for (int i = yPosition - 1; i >= 0; i--)
        {
            if (grid[xPosition, i] >= valueToCompare)
            {
                return false;
            }
        }

        return true;
    }

    private static bool VisibleCheckFromRight(int xPosition, int yPosition, int[,] grid, int rowLength, int valueToCompare)
    {
        for (int i = yPosition + 1; i < rowLength; i++)
        {
            if (grid[xPosition, i] >= valueToCompare)
            {
                return false;
            }
        }

        return true;
    }

    private static bool VisibleCheckFromTop(int xPosition, int yPosition, int[,] grid, int valueToCompare)
    {
        for (int i = xPosition - 1; i >= 0; i--)
        {
            if (grid[i, yPosition] >= valueToCompare)
            {
                return false;
            }
        }

        return true;
    }

    private static bool VisibleCheckFromDown(int xPosition, int yPosition, int[,] grid, int rowLength, int valueToCompare)
    {
        for (int i = xPosition + 1; i < rowLength; i++)
        {
            if (grid[i, yPosition] >= valueToCompare)
            {
                return false;
            }
        }

        return true;
    }

    public static int GetTreeScenicScore(int xPosition, int yPosition, int[,] grid)
    {
        var rowLength = (int)Math.Sqrt(grid.Length);

        int treeHeightToCompare = grid[xPosition, yPosition];

        var finalResult = VisibleTreeCheckToLeft(xPosition, yPosition, grid, treeHeightToCompare)
                          * VisibleTreeCheckToRight(xPosition, yPosition, grid, rowLength, treeHeightToCompare)
                          * VisibleTreeCheckToTop(xPosition, yPosition, grid, treeHeightToCompare)
                          * VisibleTreeCheckToDown(xPosition, yPosition, grid, rowLength, treeHeightToCompare);

        return finalResult;
    }
    
    private static int VisibleTreeCheckToLeft(int xPosition, int yPosition, int[,] grid, int valueToCompare)
    {
        int counter = 0;
        for (int i = yPosition - 1; i >= 0; i--)
        {
            counter++;
            if (grid[xPosition, i] >= valueToCompare)
            {
                return counter;
            }
        }

        return counter;
    }

    private static int VisibleTreeCheckToRight(int xPosition, int yPosition, int[,] grid, int rowLength, int valueToCompare)
    {
        int counter = 0;
        for (int i = yPosition + 1; i < rowLength; i++)
        {
            counter++;
            if (grid[xPosition, i] >= valueToCompare)
            {
                return counter;
            }
        }

        return counter;
    }

    private static int VisibleTreeCheckToTop(int xPosition, int yPosition, int[,] grid, int valueToCompare)
    {
        int counter = 0;
        for (int i = xPosition - 1; i >= 0; i--)
        {
            counter++;
            if (grid[i, yPosition] >= valueToCompare)
            {
                return counter;
            }
        }

        return counter;
    }

    private static int VisibleTreeCheckToDown(int xPosition, int yPosition, int[,] grid, int rowLength, int valueToCompare)
    {
        int counter = 0;
        for (int i = xPosition + 1; i < rowLength; i++)
        {
            counter++;
            if (grid[i, yPosition] >= valueToCompare)
            {
                return counter;
            }
        }

        return counter;
    }
}