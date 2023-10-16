package com.example.myapp.presentation.welcome

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.navigation.fragment.findNavController
import androidx.preference.PreferenceManager
import com.example.myapp.R
import com.example.myapp.databinding.FragmentWelcomeBinding
import com.example.myapp.presentation.onboarding.OnboardingFragment

class WelcomeFragment : Fragment() {
    private lateinit var binding: FragmentWelcomeBinding

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        binding = FragmentWelcomeBinding.inflate(inflater, container, false)

        binding.getStartedBtn.setOnClickListener {
            context?.let { ctx ->
                val preferenceManager = PreferenceManager.getDefaultSharedPreferences(ctx)

                val isOnboardingCompleted = preferenceManager.getBoolean(OnboardingFragment.ONBOARDING_COMPLETED_PREF_NAME, false)

                val preferenceEditor = preferenceManager.edit()
                preferenceEditor.putBoolean(WELCOME_COMPLETED_PREF_NAME, true)
                preferenceEditor.apply()

                if (!isOnboardingCompleted) {
                    findNavController().navigate(R.id.action_welcomeFragment_to_onboardingFragment)
                }
                else {
                    findNavController().navigate(R.id.action_welcomeFragment_to_homeFragment)
                }
            }
        }

        return binding.root
    }

    companion object {
        const val WELCOME_COMPLETED_PREF_NAME: String = "WELCOME_COMPLETED"
    }
}