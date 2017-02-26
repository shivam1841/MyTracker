package comp304.group_project;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.List;

public class search extends AppCompatActivity {

    Context ctx;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_search);

        ctx = this.getApplicationContext();

        new AsyncTask<String, Void, String>(){

            // Context context;
            @Override
            protected String doInBackground(String... urlStr){
                // do stuff on non-UI thread
                StringBuffer htmlCode = new StringBuffer();
                try{
                    HttpURLConnection conn = null;
                    URL url = new URL(urlStr[0]);
                    //    context = urlStr[1];
                    conn = (HttpURLConnection) url.openConnection();

                    //retrieve the shared data

                    SharedPreferences pref = ctx.getSharedPreferences("shared-data", Context.MODE_PRIVATE);
                    String user_name = pref.getString("username","shivam");
                    //retrieval over

                    conn.setConnectTimeout(6000);
                    conn.setReadTimeout(6000);
                    conn.setRequestMethod("POST");
                    OutputStream outputStream = conn.getOutputStream();
                    BufferedWriter bufferedWriter = new BufferedWriter(new OutputStreamWriter(outputStream, "UTF-8"));
                    String post_data = URLEncoder.encode("user_name","UTF-8")+"="+ URLEncoder.encode(user_name,"UTF-8");

                    bufferedWriter.write(post_data);
                    bufferedWriter.flush();
                    bufferedWriter.close();
                    outputStream.close();

                    BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream(),"iso-8859-1"));
                    conn.connect();

                    String inputLine;

                    while ((inputLine = in.readLine()) != null) {
                        htmlCode.append(inputLine);
                    }
                    in.close();
                } catch (Exception e) {
                    e.printStackTrace();

                }
                return htmlCode.toString();
            }

            @Override
            protected void onPostExecute(String htmlCode){
                // do stuff on UI thread with the html

                ListView lv = (ListView) findViewById(R.id.search);
                List<String> your_array_list = new ArrayList<String>();

//


                String str[];
                try {
                    SharedPreferences pref;
                    pref = ctx.getSharedPreferences("shared-data", Context.MODE_PRIVATE);
                    String user_name = pref.getString("username","shivam");
                    JSONArray jArray = new JSONArray(htmlCode.toString());
                    for(int i=0; i < jArray.length(); i++) {
                        JSONObject jObject = jArray.getJSONObject(i);
                       if(jObject.getString("Name").equals(user_name));
                        else
                        your_array_list.add(jObject.getString("Name"));

                    }

                    ArrayAdapter<String> arrayAdapter = new ArrayAdapter<String>(getApplicationContext(),android.R.layout.simple_list_item_1,your_array_list );

                    lv.setAdapter(arrayAdapter);
                    //JSONObject reader = new JSONObject(htmlCode.toString());

                    // String str = reader.getString("Name");
                    // textView.setText(str);
                    // Log.d(TAG, "onPostExecute: No Error");
                    // AlertDialog alertDialog = new AlertDialog.Builder(ctx).create();
                    //  alertDialog.setTitle("Login Status");
                    lv.setOnItemClickListener(new AdapterView.OnItemClickListener(){

                        @Override
                        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

                            Intent intent;
                            intent = new Intent(getApplicationContext(),user_profile.class);
                            intent.putExtra("activity_name","search");
                            SharedPreferences pref;
                            pref = ctx.getSharedPreferences("shared-data", Context.MODE_PRIVATE);
                            SharedPreferences.Editor ed = pref.edit();
                            ed.putString("friendname", (String)parent.getItemAtPosition(position));
                            ed.commit();
                            startActivity(intent);
                        }

                    });






                } catch (JSONException e) {
                    e.printStackTrace();


                }

                //   String[] nearby_list = csvParser(str);


                //            lv.setAdapter(arrayAdapter);
            }


        }.execute("http://dataofdata.com/search.php");

    }
}


