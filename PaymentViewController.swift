//
//  PaymentViewController.swift
//  VRShopper
//
//  Created by Ken Lee on 4/27/19.
//  Copyright © 2019 james luo. All rights reserved.
//

import UIKit
import Firebase
import FirebaseDatabase
import Canvas


class PaymentViewController: UIViewController {

    @IBOutlet weak var theTotal: UILabel!
    
    
    
    @IBAction func Pay(_ sender: UIButton) {
        cartList.removeAll()
    }
    
    @IBAction func SendToVR(_ sender: Any) {
        let ref = Database.database().reference()
        ref.setValue(["Cart": cartList])
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
        theTotal.text = "Total: $" +  String(calcPrice())
        
    }
    
    
    func calcPrice() -> Int {
        var myTotal = 0
        for i in cartList{
            for j in myTable{
                if(i == j.ItemID){
                    myTotal += j.ItemPrice
                }
            }
        }
        return myTotal
        
    }
        
    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        // Get the new view controller using segue.destination.
        // Pass the selected object to the new view controller.
    }
    */

}

