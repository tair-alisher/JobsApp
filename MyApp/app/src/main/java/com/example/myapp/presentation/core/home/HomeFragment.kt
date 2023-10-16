package com.example.myapp.presentation.core.home

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import androidx.preference.PreferenceManager
import com.example.myapp.databinding.FragmentHomeBinding
import com.example.myapp.presentation.onboarding.OnboardingFragment
import com.example.myapp.presentation.welcome.WelcomeFragment

class HomeFragment : Fragment() {
    private lateinit var binding: FragmentHomeBinding

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        binding = FragmentHomeBinding.inflate(inflater, container, false)

        binding.turnOnWelcome.setOnClickListener {
            context?.let { ctx ->
                PreferenceManager.getDefaultSharedPreferences(ctx).edit().apply {
                    putBoolean(WelcomeFragment.WELCOME_COMPLETED_PREF_NAME, false)
                    apply()
                }
            }
        }

        binding.turnOnOnboarding.setOnClickListener {
            context?.let { ctx ->
                PreferenceManager.getDefaultSharedPreferences(ctx).edit().apply {
                    putBoolean(OnboardingFragment.ONBOARDING_COMPLETED_PREF_NAME, false)
                    apply()
                }
            }
        }

        return binding.root
    }

}