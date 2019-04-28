//
//  shoppingItem.swift
//  VRShopper
//
//  Created by james luo on 4/26/19.
//  Copyright © 2019 james luo. All rights reserved.
//

import Foundation
class ShoppingItem{
    var ItemName: String
    var ItemPrice:Int
    var ItemID: Int
    var ItemPhoto: String
    var ItemDescription: String
    init(itemName:String, itemPrice:Int, ItemID: Int, itemPhoto: String, ItemDescription: String) {
        self.ItemName = itemName
        self.ItemPrice = itemPrice
        self.ItemID = ItemID
        self.ItemPhoto = itemPhoto
        self.ItemDescription = ItemDescription
        
    }
}



