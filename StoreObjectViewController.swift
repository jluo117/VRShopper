//
//  StoreObjectViewController.swift
//  VRShopper
//
//  Created by Ken Lee on 4/26/19.
//  Copyright © 2019 james luo. All rights reserved.
//

import UIKit

class StoreObjectViewController: UIViewController {

    @IBOutlet weak var theObjectName: UILabel!
    @IBOutlet weak var theObjectPrice: UILabel!
    
    //@IBOutlet weak var testOuput: UILabel!
    
    @IBOutlet weak var Image: UIImageView!
    
    
    @IBOutlet weak var Description: UILabel!
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
       
        let a = myTable[CurIndex]
         Image.image = UIImage(named: a.ItemPhoto)
        theObjectName.text = a.ItemName
        theObjectPrice.text = "Price: $" + String(a.ItemPrice)
        
        Description.text = a.ItemDescription
        
        
        // Do any additional setup after loading the view.
    }
    
    @IBAction func AddToCart(_ sender: UIButton) {
        if (myTable[CurIndex].ItemID == 7){
            let alert = UIAlertController(title: "Out of Stock", message: "Please refer to Vision for the last battery in the world", preferredStyle: .alert)
            self.present(alert,animated: true)
            alert.addAction(UIAlertAction(title: "OK", style: .default, handler: {
                action in
            }))
            return
        }
        cartList.append(myTable[CurIndex].ItemID)
        print(cartList.count)
        //testOuput.text = String(cartList.count)
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
