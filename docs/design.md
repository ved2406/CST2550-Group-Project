CLASS PestRecord
    INTEGER id
    STRING pestType        (e.g. "Rats", "Cockroaches")
    STRING location        (e.g. "London, Southall")
    STRING severity        (e.g. "Low", "Medium", "High")
    STRING status          (e.g. "Pending", "In Progress", "Resolved")
    STRING technicianName
    STRING treatmentApplied
    DATE dateReported
END CLASS

CLASS BSTNode
    PestRecord data
    BSTNode left
    BSTNode right

    CONSTRUCTOR(PestRecord record)
        data = record
        left = NULL
        right = NULL
    END CONSTRUCTOR
END CLASS


FUNCTION Insert(BSTNode root, PestRecord record)
    IF root == NULL THEN
        RETURN new BSTNode(record)
    END IF

    IF record.id < root.data.id THEN
        root.left = Insert(root.left, record)
    ELSE IF record.id > root.data.id THEN
        root.right = Insert(root.right, record)
    END IF

    RETURN root
END FUNCTION

FUNCTION Search(BSTNode root, INTEGER id)
    IF root == NULL THEN
        RETURN "Record Not Found"
    END IF

    IF id == root.data.id THEN
        RETURN root.data
    ELSE IF id < root.data.id THEN
        RETURN Search(root.left, id)
    ELSE
        RETURN Search(root.right, id)
    END IF
END FUNCTION

FUNCTION Delete(BSTNode root, INTEGER id)
    IF root == NULL THEN
        RETURN NULL
    END IF

    IF id < root.data.id THEN
        root.left = Delete(root.left, id)
    ELSE IF id > root.data.id THEN
        root.right = Delete(root.right, id)
    ELSE
        // Node found - 3 cases:

        // Case 1: No children (leaf node)
        IF root.left == NULL AND root.right == NULL THEN
            RETURN NULL
        END IF

        // Case 2: One child
        IF root.left == NULL THEN
            RETURN root.right
        ELSE IF root.right == NULL THEN
            RETURN root.left
        END IF

        // Case 3: Two children
        // Find smallest value in right subtree
        BSTNode minNode = FindMin(root.right)
        root.data = minNode.data
        root.right = Delete(root.right, minNode.data.id)
    END IF

    RETURN root
END FUNCTION

FUNCTION InOrder(BSTNode root)
    IF root == NULL THEN
        RETURN
    END IF

    InOrder(root.left)
    PRINT root.data
    InOrder(root.right)
END FUNCTION
