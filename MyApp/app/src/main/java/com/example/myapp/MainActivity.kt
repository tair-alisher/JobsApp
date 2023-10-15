package com.example.myapp

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import androidx.core.splashscreen.SplashScreen.Companion.installSplashScreen
import androidx.navigation.fragment.NavHostFragment
import androidx.navigation.ui.setupWithNavController
import androidx.preference.PreferenceManager
import com.example.myapp.databinding.ActivityMainBinding
import com.example.myapp.presentation.onboarding.OnboardingFragment
import com.example.myapp.presentation.welcome.WelcomeFragment

class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding

    override fun onCreate(savedInstanceState: Bundle?) {

        super.onCreate(savedInstanceState)
        setTheme(R.style.Theme_MyApp)

        binding = ActivityMainBinding.inflate(layoutInflater)
        val navHostFragment = supportFragmentManager.findFragmentById(R.id.fragment_container) as NavHostFragment
        val navController = navHostFragment.navController

        PreferenceManager.getDefaultSharedPreferences(this).apply {
            if (!getBoolean(WelcomeFragment.WELCOME_COMPLETED_PREF_NAME, false)) {
                navController.navigate(R.id.action_homeFragment_to_welcomeFragment)
            } else if (!getBoolean(OnboardingFragment.ONBOARDING_COMPLETED_PREF_NAME, false)) {
                navController.navigate(R.id.action_homeFragment_to_onboardingFragment)
            }
        }

        binding.bottomMenu.setupWithNavController(navController)

        navController.addOnDestinationChangedListener{ _, destination, _ ->
            if (destination.id == R.id.loginFragment ||
                destination.id == R.id.registerFragment ||
                destination.id == R.id.onboardingFragment ||
                destination.id == R.id.welcomeFragment) {
                binding.bottomMenu.visibility = View.GONE
            } else {
                binding.bottomMenu.visibility = View.VISIBLE
            }
        }

        setContentView(binding.root)
    }
}