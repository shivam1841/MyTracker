package comp304.group_project;

import android.app.DatePickerDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.SharedPreferences;
import android.icu.util.Calendar;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.support.annotation.RequiresApi;
import android.support.v4.app.DialogFragment;
import android.support.v7.app.AppCompatActivity;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;

public class registration extends AppCompatActivity {

    private EditText mName, mEmail_address, mPassword;
    private RadioButton radioButton;
    private RadioGroup radioGender;
    static int selectedGender=0, genderToSetInDB;
    private static Button btn_dob;
    static String dob = "01/01/1991", gender="Male";
    Context ctx;
    String name, email_address,password;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registration);
        ctx = this;

        mName = (EditText) findViewById(R.id.name);
        mEmail_address = (EditText) findViewById(R.id.email_address);
        mPassword = (EditText) findViewById(R.id.reg_password);

        btn_dob = (Button) findViewById(R.id.btn_dob);
        radioGender = (RadioGroup) findViewById(R.id.radioGender);

    }

    public void showDatePickerDialog(View v) {
        DialogFragment newFragment = new DatePickerFragment();
        newFragment.show(getSupportFragmentManager(), "datePicker");
    }
    public static class DatePickerFragment extends DialogFragment
            implements DatePickerDialog.OnDateSetListener {


        @RequiresApi(api = Build.VERSION_CODES.N)
        @Override
        public Dialog onCreateDialog(Bundle savedInstanceState) {
            // Use the current date as the default date in the picker
            final Calendar c = Calendar.getInstance();
            int year = c.get(Calendar.YEAR);
            int month = c.get(Calendar.MONTH);
            int day = c.get(Calendar.DAY_OF_MONTH);

            // Create a new instance of DatePickerDialog and return it
            return new DatePickerDialog(getActivity(), this, year, month+1, day);
        }

        public void onDateSet(DatePicker view, int year, int month, int day) {
            // Do something with the date chosen by the user
            //Toast.makeText(getContext(), day + "," + month + "," + year,Toast.LENGTH_LONG).show();
            dob = year +"-" + (month+1) +"-"+ day;
            btn_dob.setText(dob);
        }
    }

    public void doRegistration(View view) {
        validateRegistration();
    }

    private void validateRegistration() {
        // set error to null initially
        mName.setError(null);
        mEmail_address.setError(null);
        mPassword.setError(null);

        // store values at the time of registration attemp
        name = mName.getText().toString();
        email_address = mEmail_address.getText().toString();
        password = mPassword.getText().toString();

        boolean cancel = false;
        View focus = null;

        if (TextUtils.isEmpty(name)) {
            mName.setError("This field is required!");
            focus = mName;
            cancel = true;
        } else {
            if (TextUtils.isEmpty(email_address)) {
                mEmail_address.setError("This field is required!");
                focus = mEmail_address;
                cancel = true;
            } else {
                if (TextUtils.isEmpty(password)) {
                    mPassword.setError("This field is required!");
                    focus = mPassword;
                    cancel = true;
                }
            }
        }



        // check if there is any error, do not proceed to registration
        if (cancel == true) {
            focus.requestFocus();
        } else {
            selectedGender = radioGender.getCheckedRadioButtonId();
            radioButton = (RadioButton) findViewById(selectedGender);
            gender = radioButton.getText().toString();
            if(gender.equals("male")){
                genderToSetInDB = 1;
            } else {
                genderToSetInDB = 0;
            }
            // variable to send in database
            /*
                user_id, name, email_address, password, location, genderToSetInDB, dob
            */


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


                        //retrieval over

                        conn.setConnectTimeout(6000);
                        conn.setReadTimeout(6000);
                        conn.setRequestMethod("POST");
                        OutputStream outputStream = conn.getOutputStream();
                        BufferedWriter bufferedWriter = new BufferedWriter(new OutputStreamWriter(outputStream, "UTF-8"));
                        String post_data = URLEncoder.encode("user_name","UTF-8")+"="+ URLEncoder.encode(name,"UTF-8")+"&"
                                +URLEncoder.encode("email","UTF-8")+"="+URLEncoder.encode(email_address,"UTF-8")+"&"
                                +URLEncoder.encode("password","UTF-8")+"="+URLEncoder.encode(password,"UTF-8")+"&"
                                +URLEncoder.encode("dob","UTF-8")+"="+URLEncoder.encode(dob,"UTF-8")+"&"
                                +URLEncoder.encode("gender","UTF-8")+"="+URLEncoder.encode(String.valueOf(genderToSetInDB),"UTF-8");
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


            }.execute("http://dataofdata.com/registration.php");
            


        }
    }
}