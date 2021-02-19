using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionBrain : MonoBehaviour
{
    [HideInInspector] public Entity entity;
    SelectorToDo _neuroneStart;

    [Header("Moving")]
    public float beforeMove = 5f;
    public float disanceMaxMove = 4f;

    [Header("Attack")]
    public float aggroRange = 4f;
    public float attackRange = 1f;

    // Start is called before the first frame update
    void Start()
    {
        entity = gameObject.GetComponent<Entity>();
        if (entity == null) Debug.LogError("DecisionBrain need to be linked on an entity");

        // Premeir selector
        _neuroneStart = new SelectorToDo();
        // Sequence 1 du selector
        SequenceToDo sq1 = new SequenceToDo();
        {
            ConditionToDo conditionVisible = new EnemyIsVisible(this);
            sq1.Add(conditionVisible);

            ActionToDo moveTo = new MoveToEnemy(this);
            sq1.Add(moveTo);

            SelectorToDo slc2 = new SelectorToDo();
            sq1.Add(slc2);

            SequenceToDo sq3 = new SequenceToDo();
            {
                ConditionToDo conditionRange = new EnemyInRange(this);
                sq3.Add(conditionRange);

                ActionToDo attack = new ActionAttack(this);
                sq3.Add(attack);
            }
            slc2.Add(sq3);
        }
        // Sequence 2 du selector
        SequenceToDo sq2 = new SequenceToDo();
        {
            ConditionToDo conditionTime = new WaitMove(this);
            sq2.Add(conditionTime);

            ActionToDo moveTo = new MoveToRandom(this);
            sq2.Add(moveTo);
        }
        _neuroneStart.Add(sq1);
        _neuroneStart.Add(sq2);
        // Deuxieme selector, activé à la fin de la sequence 1

        

        /*
        ActionToDo action1 = new ActionAttack(this);
        ActionToDo action2 = new MoveToEnemy();

        
        condition2.NextYes = action1;
        condition2.NextNo = action2;

        ConditionToDo condition1 = new EnemyIsVisible();
        condition1.NextYes = condition2;
        condition1.NextNo = condition1;
        */
    }

    void Update()
    {
        if(_neuroneStart.state == NodeState.Finished ) _neuroneStart.Play();
    }

    


}
