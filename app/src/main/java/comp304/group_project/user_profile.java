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
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import org.apache.http.NameValuePair;
import org.apache.http.message.BasicNameValuePair;
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

public class user_profile extends AppCompatActivity {

    String userID, user_name, user_email, user_dob, user_gender;
    TextView tv_userID, tv_user_name, tv_user_email, tv_user_dob;
    Button chat, follow;
    ImageView iv_user;

    JSONObject user;

    // JSON parser class
    JSONParser jsonParser = new JSONParser();

    // single user url
    // ip address to be changed by server address
    private static final String url_get_profile = "http://dataofdata.com/getprofile.php";

    // JSON Node names
    private static final String TAG_SUCCESS = "success";
    private static final String TAG_USER = "user";
    private static final String TAG_NAME = "Name";
    private static final String TAG_USERID = "UserID";
    private static final String TAG_EMAIL = "Email Address";
    private static final String TAG_DOB = "DOB";
    private static final String TAG_GENDER = "Gender";
    Context ctx;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_profile);
        //       Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
//        setSupportActionBar(toolbar);
        ctx = this;

        TextView info = (TextView) findViewById(R.id.info);
        chat = (Button) findViewById(R.id.chatt);
        follow = (Button) findViewById(R.id.follow);

        //*************************************************
        // know which intent started the activity and enable/disable chat button accordingly
        Intent get_calling_activity = getIntent();
        String calling_activity = get_calling_activity.getStringExtra("activity_name");
        if(calling_activity.equals("contact")) {
            chat.setEnabled(true);
            info.setVisibility(View.INVISIBLE);
        }
        else {
            chat.setEnabled(false);
            info.setText("If you are already following the user, please go to the contact list and click \"Say HI\" button.");
            info.setVisibility(View.VISIBLE);
        }

        //*************************************************

        chat.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent;
                intent = new Intent(ctx,ChatActivity.class);
                SharedPreferences pref;
                pref = ctx.getSharedPreferences("shared-data", Context.MODE_PRIVATE);
                SharedPreferences.Editor ed = pref.edit();
                ed.putString("friendname", user_name);
                ed.commit();
                startActivity(intent);

            }
        });

        follow.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // follow
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

                            String friend_name = pref.getString("friendname","vedank");
                            //retrieval over

                            Log.d("$$$$$$$$$$$$", friend_name);
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
                        Toast.makeText(getApplicationContext(), htmlCode.toString(), Toast.LENGTH_SHORT).show();
                    }


                }.execute("http://dataofdata.com/follow.php");


            }
        });

        tv_user_name = (TextView) findViewById(R.id.tv_user_name);
        tv_user_email = (TextView) findViewById(R.id.tv_user_email);
        tv_user_dob = (TextView) findViewById(R.id.tv_user_dob);
        iv_user = (ImageView) findViewById(R.id.user_image);

        Intent in = getIntent();

        // Getting user details in background thread
        new GetProfile().execute();
    }

    // required to open chat window for particular user
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        //  getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        // to change action_chat, right click on it, go to declaration, in menu_main.xml, change it
        // can add more action item there
        // string resource file, change text in action_setting


        return super.onOptionsItemSelected(item);
    }

    // getting user information from the database
    class GetProfile extends AsyncTask<String, String, String> {

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected String doInBackground(String... params) {

            int success;
            try {
                // Building Parameters
                List<NameValuePair> param = new ArrayList<NameValuePair>();
                SharedPreferences pref = ctx.getSharedPreferences("shared-data", Context.MODE_PRIVATE);
                user_name = pref.getString("username","shivam");
                String friend_name = pref.getString("friendname","vedank");

                param.add(new BasicNameValuePair("UserID", friend_name));

                // getting user details by making HTTP request
                // Note that user details url will use GET request
                JSONObject json = jsonParser.makeHttpRequest(
                        url_get_profile, "GET", param);

                Log.d("Single User Details", json.toString());

                // json success tag
                success = json.getInt(TAG_SUCCESS);
                //success=1;

                if (success == 1) {
                    // successfully received user details
                    JSONArray userObj = json
                            .getJSONArray(TAG_USER); // JSON Array

                    // get first user object from JSON Array
                    user = userObj.getJSONObject(0);

                    // store user details in global variables
                    user_name = user.getString(TAG_NAME);
                    user_email = user.getString(TAG_EMAIL);
                    user_dob = user.getString(TAG_DOB);
                    user_gender = user.getString(TAG_GENDER);

                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            // update textview
                            try {
                                tv_user_name.setText(user.getString(TAG_NAME));
                                tv_user_email.setText(user.getString(TAG_EMAIL));
                                tv_user_dob.setText(user.getString(TAG_DOB));

                                // set the avatar of user according to gender
                                // 1 for male, 0 female
                                if(user_gender.equals("0")) {
                                    iv_user.setImageResource(R.drawable.female);
                                }
                                else {
                                    iv_user.setImageResource(R.drawable.male);
                                }


                            } catch (JSONException e) {
                                e.printStackTrace();
                            }
                        }
                    });


                } else {
                    // product with user id not found
                }
            } catch (JSONException e) {
                e.printStackTrace();
            } finally {

            }
            return null;
        }

        @Override
        protected void onPostExecute(String result) {
            super.onPostExecute(result);
        }
    }

    // method to update textviwe
    private void update_data() {
        tv_user_name.setText(user_name);
        tv_user_email.setText(user_email);
        tv_user_dob.setText(user_dob);
    }
}