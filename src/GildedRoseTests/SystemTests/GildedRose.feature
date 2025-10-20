Feature: Guilded Rose Requirements

Background:
    Given I have an item

Scenario: At the end of each day our system lowers SellIn and Quality values for every item
    When the items are updated at the end of the day
    Then the SellIn value is lowered
    And the Quality value is lowered

Scenario: Once the sell by date has passed, Quality degrades twice as fast
    Given the item has a SellIn value of 0
    When the items are updated at the end of the day
    Then the Quality value is lowered twice

Scenario: The Quality of an item is never negative
    Given the item has a Quality value of 0
    When the items are updated at the end of the day
    Then the Quality value equals 0

Scenario: "Aged Brie" actually increases in Quality the older it gets
    Given the item is named "Aged Brie"
    When the items are updated at the end of the day
    Then the Quality value is increased

Scenario: The Quality of an item is never more than 50
    Given the item is named "Aged Brie"
    And the item has a Quality value of 50
    When the items are updated at the end of the day
    Then the Quality value equals 50

Scenario: "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
    Given the item is named "Sulfuras, Hand of Ragnaros"
    And the item has a SellIn value of 0
    And the item has a Quality value of 80
    When the items are updated at the end of the day
    Then the SellIn value equals 0
    And the Quality value equals 80

Scenario Outline: "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches; Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert
    Given the item is named "Backstage passes to a TAFKAL80ETC concert"
    And the item has a SellIn value of <s1>
    And the item has a Quality value of <q1>
    When the items are updated at the end of the day
    Then the SellIn value equals <s2>
    And the Quality value equals <q2>

    Examples:
        | s1 | q1 | s2 | q2 |
        | 11 | 10 | 10 | 11 |
        | 10 | 10 |  9 | 12 |
        |  5 | 10 |  4 | 13 |
        |  1 | 10 |  0 | 13 |
        |  0 | 10 | -1 |  0 |