package comp304.group_project;

import android.app.Activity;
import android.app.Application;
import android.content.Context;
import android.content.SharedPreferences;
import android.database.DataSetObserver;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.widget.AbsListView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

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
import java.sql.Date;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import android.os.Handler;

public class ChatActivity extends AppCompatActivity {
    private static final String TAG = "ChatActivity";

    private final Handler handler = new Handler();

    private ChatArrayAdapter chatArrayAdapter;
    private ListView listView;
    private EditText chatText;
    private Button buttonSend;
    private boolean side = true;
    Context ctx;
    String user_name;
    String friend_name;
    int UserID;
    int FriendID;
    String msg;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chatactivity);
        ctx = this;
        buttonSend = (Button) findViewById(R.id.send);

        listView = (ListView) findViewById(R.id.msgview);

        chatArrayAdapter = new ChatArrayAdapter(getApplicationContext(), R.layout.right);
        listView.setAdapter(chatArrayAdapter);

        chatText = (EditText) findViewById(R.id.msg);
        chatText.setOnKeyListener(new View.OnKeyListener() {
            public boolean onKey(View v, int keyCode, KeyEvent event) {
                if ((event.getAction() == KeyEvent.ACTION_DOWN) && (keyCode == KeyEvent.KEYCODE_ENTER)) {
                    return sendChatMessage();
                }
                return false;
            }
        });
        buttonSend.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View arg0) {
                sendChatMessage();
            }
        });

        listView.setTranscriptMode(AbsListView.TRANSCRIPT_MODE_ALWAYS_SCROLL);
        listView.setAdapter(chatArrayAdapter);

        //to scroll the list view to bottom on data change
        chatArrayAdapter.registerDataSetObserver(new DataSetObserver() {
            @Override
            public void onChanged() {
                super.onChanged();
                listView.setSelection(chatArrayAdapter.getCount() - 1);
            }
        });

        new temp1().execute("http://dataofdata.com/chatID.php");
        new temp2().execute("http://dataofdata.com/chat.php");

        //doTheAutoRefresh();
    }
    //********************************************************************
    class temp1 extends AsyncTask<String, Void, String> {
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }
        @Override
        protected String doInBackground(String... urlStr) {
            // do stuff on non-UI thread
            StringBuffer htmlCode = new StringBuffer();
            try{
                HttpURLConnection conn = null;
                URL url = new URL(urlStr[0]);
                //    context = urlStr[1];
                conn = (HttpURLConnection) url.openConnection();

                //retrieve the shared data

                SharedPreferences pref = ctx.getSharedPreferences("shared-data", Context.MODE_PRIVATE);
                user_name = pref.getString("username","shivam");
                friend_name = pref.getString("friendname","vedank");

                Log.d("===============", friend_name);
                //retrieval over

                conn.setConnectTimeout(6000);
                conn.setReadTimeout(6000);
                conn.setRequestMethod("POST");
                OutputStream outputStream = conn.getOutputStream();
                BufferedWriter bufferedWriter = new BufferedWriter(new OutputStreamWriter(outputStream, "UTF-8"));
                String post_data = URLEncoder.encode("user_name","UTF-8")+"="+ URLEncoder.encode(user_name,"UTF-8")+"&"
                        +URLEncoder.encode("friend_name","UTF-8")+"="+URLEncoder.encode(friend_name,"UTF-8");
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
            String str[];
            try {

                JSONObject jObject = new JSONObject(htmlCode.toString());
                UserID = Integer.parseInt(jObject.getString("userID"));
                FriendID = Integer.parseInt(jObject.getString("friendID"));
            } catch (JSONException e1) {
                e1.printStackTrace();
            }

            //   String[] nearby_list = csvParser(str);


            //            lv.setAdapter(arrayAdapter);
        }

    }


    class temp2 extends AsyncTask<String, Void, String> {
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected String doInBackground(String... urlStr) {
            // do stuff on non-UI thread
            StringBuffer htmlCode = new StringBuffer();
            try{
                HttpURLConnection conn = null;
                URL url = new URL(urlStr[0]);
                //    context = urlStr[1];
                conn = (HttpURLConnection) url.openConnection();

                //retrieve the shared data

                SharedPreferences pref = ctx.getSharedPreferences("shared-data", Context.MODE_PRIVATE);
                user_name = pref.getString("username","shivam");
                friend_name = pref.getString("friendname","vedank");

                //retrieval over

                conn.setConnectTimeout(6000);
                conn.setReadTimeout(6000);
                conn.setRequestMethod("POST");
                OutputStream outputStream = conn.getOutputStream();
                BufferedWriter bufferedWriter = new BufferedWriter(new OutputStreamWriter(outputStream, "UTF-8"));
                String post_data = URLEncoder.encode("user_name","UTF-8")+"="+ URLEncoder.encode(user_name,"UTF-8")+"&"
                        +URLEncoder.encode("friend_name","UTF-8")+"="+URLEncoder.encode(friend_name,"UTF-8");
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
            String str[];
            try {
                chatArrayAdapter.clear();
                JSONArray jArray = new JSONArray(htmlCode.toString());
                JSONObject[] jsonObjects = new JSONObject[jArray.length()];

                for(int i=0; i < jArray.length(); i++) {
                    JSONObject jObject = jArray.getJSONObject(i);
                    jsonObjects[i] = jObject;
                }

                Collections.sort(Arrays.asList(jsonObjects), new Comparator<JSONObject>() {

                    @Override
                    public int compare(JSONObject o1, JSONObject o2) {
                        try {
                            return o1.getString("Time").compareTo(o2.getString("Time"));
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                        return 0;
                    }
                });

                for(int i=0; i < jArray.length(); i++) {


                    if(Integer.parseInt(jsonObjects[i].getString("UserID")) == UserID) {
                        chatArrayAdapter.add(new ChatMessage(true, jsonObjects[i].getString("Message").toString()));
                        //chatText.setText("");
                    }
                    else
                    {
                        chatArrayAdapter.add(new ChatMessage(false,jsonObjects[i].getString("Message").toString()));
                        //chatText.setText("");
                    }
                }



            } catch (JSONException e) {
                e.printStackTrace();


            }

            //   String[] nearby_list = csvParser(str);


            //            lv.setAdapter(arrayAdapter);
        }

    }

//********************************************************************
    /*
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
                    user_name = pref.getString("username","shivam");
                    friend_name = pref.getString("friendname","vedank");

                    Log.d("===============", friend_name);
                    //retrieval over

                    conn.setConnectTimeout(6000);
                    conn.setReadTimeout(6000);
                    conn.setRequestMethod("POST");
                    OutputStream outputStream = conn.getOutputStream();
                    BufferedWriter bufferedWriter = new BufferedWriter(new OutputStreamWriter(outputStream, "UTF-8"));
                    String post_data = URLEncoder.encode("user_name","UTF-8")+"="+ URLEncoder.encode(user_name,"UTF-8")+"&"
                            +URLEncoder.encode("friend_name","UTF-8")+"="+URLEncoder.encode(friend_name,"UTF-8");
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
                String str[];
                try {

                        JSONObject jObject = new JSONObject(htmlCode.toString());
                        UserID = Integer.parseInt(jObject.getString("userID"));
                        FriendID = Integer.parseInt(jObject.getString("friendID"));
                    } catch (JSONException e1) {
                    e1.printStackTrace();
                }

                //   String[] nearby_list = csvParser(str);


                //            lv.setAdapter(arrayAdapter);
            }


        }.execute("http://dataofdata.com/chatID.php");
    */

    /*
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
                    user_name = pref.getString("username","shivam");
                    friend_name = pref.getString("friendname","vedank");

                    //retrieval over

                    conn.setConnectTimeout(6000);
                    conn.setReadTimeout(6000);
                    conn.setRequestMethod("POST");
                    OutputStream outputStream = conn.getOutputStream();
                    BufferedWriter bufferedWriter = new BufferedWriter(new OutputStreamWriter(outputStream, "UTF-8"));
                    String post_data = URLEncoder.encode("user_name","UTF-8")+"="+ URLEncoder.encode(user_name,"UTF-8")+"&"
                            +URLEncoder.encode("friend_name","UTF-8")+"="+URLEncoder.encode(friend_name,"UTF-8");
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
                String str[];
                try {
                    JSONArray jArray = new JSONArray(htmlCode.toString());
                    JSONObject[] jsonObjects = new JSONObject[jArray.length()];

                    for(int i=0; i < jArray.length(); i++) {
                        JSONObject jObject = jArray.getJSONObject(i);
                        jsonObjects[i] = jObject;
                    }

                    Collections.sort(Arrays.asList(jsonObjects), new Comparator<JSONObject>() {

                        @Override
                        public int compare(JSONObject o1, JSONObject o2) {
                            try {
                                return o1.getString("Time").compareTo(o2.getString("Time"));
                            } catch (JSONException e) {
                                e.printStackTrace();
                            }
                            return 0;
                        }
                    });

                    for(int i=0; i < jArray.length(); i++) {


                        if(Integer.parseInt(jsonObjects[i].getString("UserID")) == UserID) {
                            chatArrayAdapter.add(new ChatMessage(true, jsonObjects[i].getString("Message").toString()));
                            chatText.setText("");
                        }
                        else
                        {
                            chatArrayAdapter.add(new ChatMessage(false,jsonObjects[i].getString("Message").toString()));
                            chatText.setText("");
                        }
                    }



                } catch (JSONException e) {
                    e.printStackTrace();


                }

                //   String[] nearby_list = csvParser(str);


                //            lv.setAdapter(arrayAdapter);
            }


        }.execute("http://dataofdata.com/chat.php");
*/
    //      doTheAutoRefresh();

    //*******************************************************************

    private void doTheAutoRefresh() {
        handler.postDelayed(new Runnable() {
            @Override
            public void run() {
                //recreate();
                new temp1().execute("http://dataofdata.com/chatID.php");
                new temp2().execute("http://dataofdata.com/chat.php");
                doTheAutoRefresh();
            }
        }, 2000);
    }
    //*******************************************************************
    private boolean sendChatMessage() {
        chatArrayAdapter.add(new ChatMessage(side, chatText.getText().toString()));
        msg = chatText.getText().toString();


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
                    user_name = pref.getString("username","shivam");
                    friend_name = pref.getString("friendname","vedank");

                    //retrieval over

                    conn.setConnectTimeout(6000);
                    conn.setReadTimeout(6000);
                    conn.setRequestMethod("POST");
                    OutputStream outputStream = conn.getOutputStream();
                    BufferedWriter bufferedWriter = new BufferedWriter(new OutputStreamWriter(outputStream, "UTF-8"));
                    String post_data = URLEncoder.encode("userID","UTF-8")+"="+ URLEncoder.encode(String.valueOf(UserID),"UTF-8")+"&"
                            +URLEncoder.encode("friendID","UTF-8")+"="+URLEncoder.encode(String.valueOf(FriendID),"UTF-8")+"&"
                            +URLEncoder.encode("message","UTF-8")+"="+URLEncoder.encode(msg,"UTF-8");
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
            }


        }.execute("http://dataofdata.com/chatUpload.php");





        //side = !side;
        return true;
    }
}