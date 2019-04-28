//
//  ViewController.swift
//  VRShopper
//
//  Created by james luo on 4/26/19.
//  Copyright © 2019 james luo. All rights reserved.
//

import UIKit
var myTable = [ShoppingItem]()
var cartList = [Int]()
var CurIndex = 0
class ViewController: UIViewController {
   
    override var preferredStatusBarStyle: UIStatusBarStyle {
        return .lightContent
    }
    
    @IBOutlet weak var Label: UILabel!
    
    override func viewDidLoad() {
        Label.text = #"Tap "Shop" To Begin"#
        let object1 = ShoppingItem(itemName: "Speaker", itemPrice: 100, ItemID: 1, itemPhoto: "speakers", ItemDescription: "This pair of speakers will rock your world. Featuring impressive color lighting and ready to spice up any moment, it is the amazing Disco Speakers!!!")
        let object2 = ShoppingItem(itemName: "TV", itemPrice: 1000, ItemID: 2, itemPhoto: "tv", ItemDescription: "Generic TV, not too fancy, not too cheap. At least it has an OLED display (which is why it is in this price range).")
        let object3 = ShoppingItem(itemName: "Chair", itemPrice: 40, ItemID: 3, itemPhoto: "chair", ItemDescription: "This chair's middle name is comfort. It is well made from premium wood and will certainly not fall apart like IKEA furniture.")
        let object4 = ShoppingItem(itemName: "Nuclear Material", itemPrice: 20000, ItemID: 4, itemPhoto: "nuclear", ItemDescription: "How did we acquire this item? Oh wouldn't you like to know.")
        let object5 = ShoppingItem(itemName: "Car", itemPrice: 1000, ItemID: 5, itemPhoto: "car", ItemDescription: "Totally Super Legit Car that can last several years. Nothing sketchy at all, just don't look too closely and avoid other cars. May implode without warning. Company is not liable for any damages, personal or otherwise.")
        let object6 = ShoppingItem(itemName: "Gauntlet", itemPrice: 1000000000, ItemID: 6, itemPhoto: "gauntlet", ItemDescription: "It is an honor to even see this product image. The presence of such an object is beyond this world. Okay times up! Stop looking at my precious.")
        let object7 = ShoppingItem(itemName: "Last Battery", itemPrice: 1, ItemID: 7, itemPhoto: "battery", ItemDescription: "Hmm... it's a battery?")
//        let object6 = ShoppingItem(itemName: "Chair", itemPrice: 35, ItemID: 6)
//        let object7 = ShoppingItem(itemName: "Table", itemPrice: 80, ItemID: 7)
//        let object8 = ShoppingItem(itemName: "Television", itemPrice: 1800, ItemID: 8)
//        let object9 = ShoppingItem(itemName: "Plant", itemPrice: 3, ItemID: 9)
//        let object10 = ShoppingItem(itemName: "Pillow", itemPrice: 6, ItemID: 10)
        
//        myTable = [object1, object2, object3, object4, object5, object6, object7, object8, object9, object10]
        
        myTable = [object1, object2, object3, object4, object5, object6, object7]
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }

}



