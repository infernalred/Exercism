using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;
    public static Tree Create(TreeBuildingRecord treeRecord) => new Tree { Children = new List<Tree>(), Id = treeRecord.RecordId, ParentId = treeRecord.ParentId };
    public static bool IsInvalid(Tree t, int previousRecordId) => t.ParentId >= t.Id || t.Id != previousRecordId + 1;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        var trees = records.OrderBy(record => record.RecordId).Select(Tree.Create).ToArray();

        if (trees.Length == 0 || trees[0].Id != 0 || trees[0].ParentId != 0 || trees.Skip(1).Where(Tree.IsInvalid).Any())
            throw new ArgumentException();

        return trees.Skip(1).Aggregate(trees, (ts, t) => { ts[t.ParentId].Children.Add(t); return ts; })[0];
    }
}