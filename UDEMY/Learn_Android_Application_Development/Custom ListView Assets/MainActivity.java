package com.jjurrius.customlistview2017;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.ListView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    ListView lvProducts;
    ArrayList<Product> products;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        lvProducts = (ListView) findViewById(R.id.lvProducts);

        products = new ArrayList<Product>();

        Product product1 = new Product("Dell Latitude 3500",
                "The world's most secure, most manageable and most reliable business-class laptops.",
                "Laptop",
                14500.99,
                true);
        Product product2 = new Product("Acer Aspire 7",
                "Revolutionary convertible computers that feature powerful innovation and forward-thinking design.",
                "Laptop",
                12500.99,
                false);
        Product product3 = new Product("SANDISK 16 GB Cruzer",
                "Low-cost, no-nonsense way of storing and transporting files.",
                "Memory",
                299.99,
                false);
        Product product4 = new Product("Verbatim 1TB",
                "Verbatim's portable hard drive product offerings are exceptionally reliable and fashionably thin.",
                "HDD",
                1020.99,
                false);

        products.add(product1);
        products.add(product2);
        products.add(product3);
        products.add(product4);

        ProductAdapter adapter = new ProductAdapter(this, products);
        lvProducts.setAdapter(adapter);
    }
}
