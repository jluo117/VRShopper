//
//  shopItemCell.swift
//  VRShopper
//
//  Created by james luo on 4/26/19.
//  Copyright © 2019 james luo. All rights reserved.
//

import UIKit

class shopItemCell: UITableViewCell {
    
    @IBOutlet weak var ItemPrice: UILabel!
    @IBOutlet weak var itemName: UILabel!
    
    
    override func awakeFromNib() {
        ItemPrice.text = "6"
        itemName.text = "gdfdf"
       // ItemID.text = "3"
        super.awakeFromNib()
        // Initialization code
    }

    override func setSelected(_ selected: Bool, animated: Bool) {
        super.setSelected(selected, animated: animated)

        // Configure the view for the selected state
    }
    

}
